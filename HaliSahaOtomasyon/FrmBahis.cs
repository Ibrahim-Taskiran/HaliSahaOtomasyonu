using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HaliSahaOtomasyon
{
    public partial class FrmBahis : DevExpress.XtraEditors.XtraForm
    {
        // Global Değişkenleri burada sadece "Tanımlıyoruz", "Oluşturmuyoruz" (new yapmıyoruz).
        // Böylece hata varsa yakalayabiliriz.
        SqlBaglantisi bgl;
        BahisIslemleri bahisMotoru;

        int secilenRandevuID = 0;
        int secilenTakim = -1;
        double secilenOran = 0.0;
        decimal kullaniciBakiyesi = 0;

        // --- KURUCU METOT ---
        public FrmBahis()
        {
            // 1. ADIM: TASARIM YÜKLEME (InitializeComponent Koruması)
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form tasarımı yüklenirken kritik hata oluştu!\nDetay: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Devam etme
            }

            // 2. ADIM: NESNELERİ OLUŞTURMA VE AYARLAR
            try
            {
                // Değişkenleri burada oluşturuyoruz (Güvenli Alan)
                bgl = new SqlBaglantisi();
                bahisMotoru = new BahisIslemleri();

                // *** MODERN TASARIM AYARLARI ***
                this.Text = "İddaa Bülteni & Bahis Yap";
                this.Appearance.BackColor = Color.FromArgb(240, 242, 245);
                this.Appearance.Options.UseBackColor = true;

                // GRUP KONTROLLERİ 
                if (grpAnaliz != null)
                {
                    grpAnaliz.AppearanceCaption.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    grpAnaliz.AppearanceCaption.ForeColor = Color.FromArgb(60, 60, 60);
                    grpAnaliz.Visible = false;
                }

                if (grpKupon != null)
                {
                    grpKupon.AppearanceCaption.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    grpKupon.AppearanceCaption.ForeColor = Color.FromArgb(60, 60, 60);
                    grpKupon.Visible = false;
                }

                // BUTONLAR 
                if (btnEvSahibi != null)
                {
                    btnEvSahibi.Appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btnEvSahibi.Appearance.ForeColor = Color.White;
                    btnEvSahibi.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                    btnEvSahibi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    btnEvSahibi.Height = 60;
                    btnEvSahibi.Cursor = Cursors.Hand;
                }

                if (btnDeplasman != null)
                {
                    btnDeplasman.Appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btnDeplasman.Appearance.ForeColor = Color.White;
                    btnDeplasman.Appearance.BackColor = Color.FromArgb(231, 76, 60);
                    btnDeplasman.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    btnDeplasman.Height = 60;
                    btnDeplasman.Cursor = Cursors.Hand;
                }

                if (btnOnayla != null)
                {
                    btnOnayla.Text = "✅ BAHİSİ ONAYLA";
                    btnOnayla.Appearance.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    btnOnayla.Appearance.ForeColor = Color.White;
                    btnOnayla.Appearance.BackColor = Color.FromArgb(46, 204, 113);
                    btnOnayla.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    btnOnayla.Height = 65;
                    btnOnayla.Dock = DockStyle.Bottom;
                    btnOnayla.Cursor = Cursors.Hand;
                }

                // ETİKETLER
                if (lblEvSahibiAd != null) { lblEvSahibiAd.Appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold); lblEvSahibiAd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; lblEvSahibiAd.AutoSizeMode = LabelAutoSizeMode.None; lblEvSahibiAd.Width = 200; }
                if (lblDeplasmanAd != null) { lblDeplasmanAd.Appearance.Font = new Font("Segoe UI", 12, FontStyle.Bold); lblDeplasmanAd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; lblDeplasmanAd.AutoSizeMode = LabelAutoSizeMode.None; lblDeplasmanAd.Width = 200; }
                if (lblOlasıKazanc != null) { lblOlasıKazanc.Appearance.Font = new Font("Segoe UI", 16, FontStyle.Bold); lblOlasıKazanc.Appearance.ForeColor = Color.Gray; lblOlasıKazanc.Dock = DockStyle.Bottom; lblOlasıKazanc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; }
                if (txtTutar != null) { txtTutar.Properties.Appearance.Font = new Font("Segoe UI", 14); txtTutar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; }

                // Verileri Yükle
                BakiyeyiGuncelle();
                BulteniGetir();
            }
            catch (Exception ex)
            {
                // Burada hata olsa bile formun açılmasını engellemeyelim, sadece uyaralım.
                MessageBox.Show("Form ayarları yapılırken bir hata oluştu: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmBahis_Load(object sender, EventArgs e)
        {
        }

        // --- BAKİYE GETİR ---
        void BakiyeyiGuncelle()
        {
            try
            {
                if (lblBakiye == null) return;

                using (SqlConnection conn = bgl.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand("SELECT Bakiye FROM Users WHERE UserId=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", UserSession.UserId);
                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null)
                    {
                        kullaniciBakiyesi = Convert.ToDecimal(sonuc);
                        lblBakiye.Text = "Cüzdan: " + kullaniciBakiyesi.ToString("C2");
                        lblBakiye.Appearance.ForeColor = Color.DarkSlateGray;
                        lblBakiye.Appearance.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    }
                }
            }
            catch { }
        }

        // --- BÜLTEN (MAÇLARI LİSTELE) ---
        void BulteniGetir()
        {
            try
            {
                if (tileControl1 == null) return;

                // 1. Önce TileControl'ün grubu var mı kontrol et, yoksa ekle 
                if (tileControl1.Groups.Count == 0)
                {
                    DevExpress.XtraEditors.TileGroup grup = new DevExpress.XtraEditors.TileGroup();
                    tileControl1.Groups.Add(grup);
                }

                // 2. Grubu temizle 
                tileControl1.Groups[0].Items.Clear();
                tileControl1.BackColor = this.Appearance.BackColor;

                // 3. Veritabanından Maçları Çek
                string sorgu = @"
                    SELECT r.RandevuID, r.Tarih, r.Saat, s.SahaTanimi 
                    FROM Randevular r
                    JOIN Sahalar s ON r.SahaID = s.SahaID
                    WHERE r.Durum = 1 AND r.Tarih >= CAST(GETDATE() AS DATE)
                    ORDER BY r.Tarih, r.Saat";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
                da.Fill(dt);

                // 4. Maçları Kutu Olarak Ekle
                foreach (DataRow dr in dt.Rows)
                {
                    TileItem item = new TileItem();
                    item.AppearanceItem.Normal.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    item.AppearanceItem.Normal.BackColor = Color.FromArgb(26, 188, 156);
                    item.AppearanceItem.Normal.BorderColor = Color.Transparent;

                    item.Elements.Add(new TileItemElement { Text = dr["SahaTanimi"].ToString(), TextAlignment = TileItemContentAlignment.TopLeft });
                    item.Elements.Add(new TileItemElement { Text = Convert.ToDateTime(dr["Tarih"]).ToShortDateString(), TextAlignment = TileItemContentAlignment.BottomLeft });
                    item.Elements.Add(new TileItemElement { Text = dr["Saat"].ToString(), TextAlignment = TileItemContentAlignment.TopRight });

                    item.Tag = dr["RandevuID"];
                    item.ItemSize = TileItemSize.Wide;
                    item.ItemClick += Item_ItemClick;

                    tileControl1.Groups[0].Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bülten yüklenirken hata oluştu: " + ex.Message);
            }
        }

        // --- MAÇA TIKLAMA OLAYI ---
        private void Item_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                secilenRandevuID = Convert.ToInt32(e.Item.Tag);
                var analiz = bahisMotoru.OranHesapla(secilenRandevuID);

                if (!analiz.BahisAcilabilirMi)
                {
                    XtraMessageBox.Show("Bu maçın kadroları henüz tamamlanmadığı için bahis oynanamaz.", "Maç Hazır Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grpAnaliz.Visible = false;
                    return;
                }

                grpAnaliz.Visible = true;
                grpKupon.Visible = false;

                lblEvSahibiAd.Text = "EV SAHİBİ";
                lblDeplasmanAd.Text = "DEPLASMAN";

                if (ratingEv != null) ratingEv.Rating = (decimal)analiz.EvSahibiGuc;
                if (ratingDep != null) ratingDep.Rating = (decimal)analiz.DeplasmanGuc;

                btnEvSahibi.Text = $"MS 1\nORAN: {analiz.OranEvSahibi.ToString("0.00")}";
                btnEvSahibi.Tag = analiz.OranEvSahibi;

                btnDeplasman.Text = $"MS 2\nORAN: {analiz.OranDeplasman.ToString("0.00")}";
                btnDeplasman.Tag = analiz.OranDeplasman;

                // VS YAZISI
                bool vsVarMi = false;
                foreach (Control ctrl in grpAnaliz.Controls) { if (ctrl.Name == "lblVS") vsVarMi = true; }
                if (!vsVarMi)
                {
                    LabelControl lblVS = new LabelControl();
                    lblVS.Name = "lblVS";
                    lblVS.Text = "VS";
                    lblVS.Appearance.Font = new Font("Segoe UI", 22, FontStyle.Bold | FontStyle.Italic);
                    lblVS.Appearance.ForeColor = Color.Silver;
                    lblVS.AutoSizeMode = LabelAutoSizeMode.None;
                    lblVS.Size = new Size(60, 50);
                    lblVS.Location = new Point((grpAnaliz.Width - 60) / 2, btnEvSahibi.Top);
                    grpAnaliz.Controls.Add(lblVS);
                    lblVS.BringToFront();
                }

                btnEvSahibi.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                btnDeplasman.Appearance.BackColor = Color.FromArgb(231, 76, 60);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maç seçilirken hata: " + ex.Message);
            }
        }

        // --- BAHİS SEÇİMİ ---
        private void BahisSec_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton btn = sender as SimpleButton;

                if (btn == btnEvSahibi) secilenTakim = 0;
                else secilenTakim = 1;

                secilenOran = Convert.ToDouble(btn.Tag);

                grpKupon.Visible = true;
                grpKupon.Text = "Kupon: " + (secilenTakim == 0 ? "Ev Sahibi" : "Deplasman");
                lblSecim.Text = $"Oran: {secilenOran.ToString("0.00")}";
                txtTutar.Text = "";
                lblOlasıKazanc.Text = "0.00 TL";

                btnEvSahibi.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                btnDeplasman.Appearance.BackColor = Color.FromArgb(231, 76, 60);
                btn.Appearance.BackColor = Color.FromArgb(230, 126, 34);
            }
            catch { }
        }

        // --- TUTAR GİRİLİNCE ---
        private void txtTutar_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTutar.Text, out decimal tutar))
            {
                decimal kazanc = tutar * (decimal)secilenOran;
                lblOlasıKazanc.Text = "Olası Kazanç: " + kazanc.ToString("C2");
                lblOlasıKazanc.Appearance.ForeColor = Color.FromArgb(39, 174, 96);
            }
            else
            {
                lblOlasıKazanc.Text = "0.00 TL";
                lblOlasıKazanc.Appearance.ForeColor = Color.Gray;
            }
        }

        // --- ONAYLA BUTONU ---
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTutar.Text, out decimal yatirilanTutar) || yatirilanTutar <= 0)
            {
                XtraMessageBox.Show("Lütfen geçerli bir tutar girin.");
                return;
            }

            if (yatirilanTutar > kullaniciBakiyesi)
            {
                XtraMessageBox.Show("Yetersiz Bakiye!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show($"{yatirilanTutar:C2} tutarındaki bahsi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            SqlTransaction trans = null;
            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    trans = conn.BeginTransaction();

                    string sqlBahis = @"INSERT INTO Bahisler (UserID, RandevuID, SecilenTakim, OynananOran, YatirilanTutar, Durum) 
                                        VALUES (@u, @r, @s, @o, @t, 0)";
                    SqlCommand cmdBahis = new SqlCommand(sqlBahis, conn, trans);
                    cmdBahis.Parameters.AddWithValue("@u", UserSession.UserId);
                    cmdBahis.Parameters.AddWithValue("@r", secilenRandevuID);
                    cmdBahis.Parameters.AddWithValue("@s", secilenTakim);
                    cmdBahis.Parameters.AddWithValue("@o", secilenOran);
                    cmdBahis.Parameters.AddWithValue("@t", yatirilanTutar);
                    cmdBahis.ExecuteNonQuery();

                    string sqlBakiye = "UPDATE Users SET Bakiye = Bakiye - @tutar WHERE UserId = @uid";
                    SqlCommand cmdBakiye = new SqlCommand(sqlBakiye, conn, trans);
                    cmdBakiye.Parameters.AddWithValue("@tutar", yatirilanTutar);
                    cmdBakiye.Parameters.AddWithValue("@uid", UserSession.UserId);
                    cmdBakiye.ExecuteNonQuery();

                    trans.Commit();
                }

                XtraMessageBox.Show("Bahis başarıyla oynandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BakiyeyiGuncelle();
                txtTutar.Text = "";
                grpKupon.Visible = false;

                btnEvSahibi.Appearance.BackColor = Color.FromArgb(52, 152, 219);
                btnDeplasman.Appearance.BackColor = Color.FromArgb(231, 76, 60);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}