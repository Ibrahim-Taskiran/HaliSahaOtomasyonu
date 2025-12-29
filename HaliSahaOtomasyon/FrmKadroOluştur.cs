using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HaliSahaOtomasyon
{
    public partial class FrmKadroOlustur : DevExpress.XtraEditors.XtraForm
    {
        public FrmKadroOlustur()
        {
            InitializeComponent();

            // Olayları Elle Bağlıyoruz
            this.Load += FrmKadroOlustur_Load;

            // SADECE SAĞ TIK OLAYINI BAĞLIYORUZ (Çift Tıklama Kaldırıldı)
            gridView1.MouseUp += gridView1_MouseUp;
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        // Gelen Veriler
        public int SecilenSahaID;
        public string SecilenTarih;
        public string SecilenSaat;

        // Listeler
        List<int> evSahibiIDs = new List<int>();
        List<int> deplasmanIDs = new List<int>();

        private void FrmKadroOlustur_Load(object sender, EventArgs e)
        {
            this.Text = "Kadro Oluştur";

            // 1. Listeyi Getir
            ArkadaslariGetir();

            // 2. Seni Ekle
            OyuncuEkle(UserSession.UserId, 0);

            // 3. ID Kutusu Olayları
            txtEvSahibiID.EditValueChanged += txtEvSahibiID_EditValueChanged;
            txtDeplasmanID.EditValueChanged += txtDeplasmanID_EditValueChanged;

            // Enter Tuşu
            txtEvSahibiID.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) btnEvSahibiEkle.PerformClick(); };
            txtDeplasmanID.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.Enter) btnDeplasmanEkle.PerformClick(); };
        }

        // --- 1. ARKADAŞLARI GETİR (READ-ONLY) ---
        void ArkadaslariGetir()
        {
            try
            {
                gridArkadaslar.MainView = gridView1;
                gridView1.Columns.Clear();

                string sorgu = @"
                    SELECT 
                        u.UserId,
                        u.FullName as [Arkadaş Adı],
                        u.Mevki,
                        u.Sehir
                    FROM Arkadaslar a
                    JOIN Users u ON (a.KimdenID = u.UserId OR a.KimeID = u.UserId)
                    WHERE (a.KimdenID = @ben OR a.KimeID = @ben) 
                      AND a.Durum = 1 
                      AND u.UserId != @ben";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
                da.SelectCommand.Parameters.AddWithValue("@ben", UserSession.UserId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridArkadaslar.DataSource = dt;
                gridView1.PopulateColumns();

                // *** KİLİTLEME AYARLARI (Sağ tıkın rahat çalışması için şart) ***
                gridView1.OptionsBehavior.Editable = false; // Hücreye yazılamaz
                gridView1.OptionsBehavior.ReadOnly = true;  // Sadece okunabilir
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false; // Hücre değil satır seçilsin
                gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                // ID Gizle
                if (gridView1.Columns["UserId"] != null) gridView1.Columns["UserId"].Visible = false;

                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // --- 2. ID İLE İSİM BULMA ---
        string IsimGetir(string idText)
        {
            if (string.IsNullOrEmpty(idText)) return "...";
            if (!int.TryParse(idText, out int id)) return "Geçersiz ID";

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT FullName FROM Users WHERE UserId=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", id);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "Kullanıcı Bulunamadı";
                }
            }
            catch { return "Hata"; }
        }

        private void txtEvSahibiID_EditValueChanged(object sender, EventArgs e)
        {
            string isim = IsimGetir(txtEvSahibiID.Text);
            lblEvSahibiIsim.Text = isim;
            lblEvSahibiIsim.ForeColor = (isim == "Kullanıcı Bulunamadı" || isim == "Geçersiz ID") ? Color.Red : Color.Green;
        }

        private void txtDeplasmanID_EditValueChanged(object sender, EventArgs e)
        {
            string isim = IsimGetir(txtDeplasmanID.Text);
            lblDeplasmanIsim.Text = isim;
            lblDeplasmanIsim.ForeColor = (isim == "Kullanıcı Bulunamadı" || isim == "Geçersiz ID") ? Color.Red : Color.Green;
        }

        // --- 3. OYUNCU EKLEME ---
        void OyuncuEkle(int oyuncuId, int takimTuru)
        {
            if (evSahibiIDs.Contains(oyuncuId) || deplasmanIDs.Contains(oyuncuId))
            {
                XtraMessageBox.Show("Bu oyuncu zaten ekli!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = IsimGetir(oyuncuId.ToString());
            if (oyuncuId == UserSession.UserId) ad = UserSession.AdSoyad;

            if (ad == "Kullanıcı Bulunamadı" || ad == "Hata" || ad == "...") return;

            if (takimTuru == 0)
            {
                evSahibiIDs.Add(oyuncuId);
                listEvSahibi.Items.Add(ad);
            }
            else
            {
                deplasmanIDs.Add(oyuncuId);
                listDeplasman.Items.Add(ad);
            }
        }

        // --- 4. BUTONLAR ---
        private void btnEvSahibiEkle_Click(object sender, EventArgs e)
        {
            if (lblEvSahibiIsim.ForeColor == Color.Green)
            {
                OyuncuEkle(Convert.ToInt32(txtEvSahibiID.Text), 0);
                txtEvSahibiID.Text = "";
                lblEvSahibiIsim.Text = "...";
                lblEvSahibiIsim.ForeColor = Color.Black;
            }
            else XtraMessageBox.Show("Geçerli bir ID giriniz.");
        }

        private void btnDeplasmanEkle_Click(object sender, EventArgs e)
        {
            if (lblDeplasmanIsim.ForeColor == Color.Green)
            {
                OyuncuEkle(Convert.ToInt32(txtDeplasmanID.Text), 1);
                txtDeplasmanID.Text = "";
                lblDeplasmanIsim.Text = "...";
                lblDeplasmanIsim.ForeColor = Color.Black;
            }
            else XtraMessageBox.Show("Geçerli bir ID giriniz.");
        }

        // --- 5. SAĞ TIK MENÜSÜ ---
        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitInfo = gridView1.CalcHitInfo(e.Location);
                if (hitInfo.InRow)
                {
                    gridView1.FocusedRowHandle = hitInfo.RowHandle; // Satırı seçili yap
                    cmsKadro.Show(gridArkadaslar, e.Location);      // Menüyü aç
                }
            }
        }

        // Context Menu Elemanları
        private void kendiTakımımaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) OyuncuEkle(Convert.ToInt32(dr["UserId"]), 0); // 0 = Ev Sahibi
        }

        private void rakipTakımaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) OyuncuEkle(Convert.ToInt32(dr["UserId"]), 1); // 1 = Deplasman
        }

        // --- 6. KAYDET ---
        private void btnMaciOnayla_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Randevu ve kadrolar kaydedilecek. Onaylıyor musunuz?", "Son Karar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            SqlTransaction trans = null;
            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    trans = conn.BeginTransaction();

                    // Randevu
                    string sql = "INSERT INTO Randevular (SahaID, UserId, Tarih, Saat, Durum) VALUES (@p1, @p2, @p3, @p4, 1); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(sql, conn, trans);
                    cmd.Parameters.AddWithValue("@p1", SecilenSahaID);
                    cmd.Parameters.AddWithValue("@p2", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@p3", SecilenTarih);
                    cmd.Parameters.AddWithValue("@p4", SecilenSaat);

                    object res = cmd.ExecuteScalar();
                    if (res == null) throw new Exception("Randevu ID alınamadı.");
                    int randevuId = Convert.ToInt32(res);

                    // Kadrolar
                    foreach (int id in evSahibiIDs)
                    {
                        SqlCommand kCmd = new SqlCommand("INSERT INTO MacKadrosu (RandevuID, OyuncuID, TakimTuru) VALUES (@r, @o, 0)", conn, trans);
                        kCmd.Parameters.AddWithValue("@r", randevuId);
                        kCmd.Parameters.AddWithValue("@o", id);
                        kCmd.ExecuteNonQuery();
                    }
                    foreach (int id in deplasmanIDs)
                    {
                        SqlCommand kCmd = new SqlCommand("INSERT INTO MacKadrosu (RandevuID, OyuncuID, TakimTuru) VALUES (@r, @o, 1)", conn, trans);
                        kCmd.Parameters.AddWithValue("@r", randevuId);
                        kCmd.Parameters.AddWithValue("@o", id);
                        kCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }

                XtraMessageBox.Show("Maç başarıyla ayarlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}