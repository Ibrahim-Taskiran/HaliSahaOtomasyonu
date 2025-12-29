using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace HaliSahaOtomasyon
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        RepositoryItemButtonEdit btnKabulEt;
        RepositoryItemButtonEdit btnReddet;
        RepositoryItemButtonEdit btnIstekGonder;

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            ButonlariHazirla();
            AramaButonunuHazirla();

            IstekleriListele();
            ArkadaslariListele();
            RandevulariYenile();
            GrafikGuncelle();

            // Çift Tıklama Olayı (Profile gitmek için)
            gridViewArkadaslar.DoubleClick -= gridViewArkadaslar_DoubleClick;
            gridViewArkadaslar.DoubleClick += gridViewArkadaslar_DoubleClick;

            this.BeginInvoke(new Action(() =>
            {
                this.PerformLayout();
                this.Refresh();
                EksikSkorKontrolu();
            }));
        }

        // --- 1. MEVCUT ARKADAŞLARI LİSTELE (PUAN SÜTUNU SİLİNDİ) ---
        // --- MEVCUT ARKADAŞLARI LİSTELE (ID GÖRÜNÜR YAPILDI - KESİN ÇÖZÜM) ---
        void ArkadaslariListele()
        {
            try
            {
                // SQL Sorgusu (ArkadasID içeriyor)
                string sorgu = @"
            SELECT 
                u.UserId as [ArkadasID],
                u.FullName as [Arkadaş],
                a.ID as [KayitID],
                a.KimdenID, 
                ISNULL(CAST(u.ToplamPuan AS FLOAT) / NULLIF(u.OySayisi, 0), 0) as [OrtalamaPuan]
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

                // *** KRİTİK EKLEME: Sütunları veriye göre sıfırdan oluştur ***
                gridViewArkadaslar.PopulateColumns();

                // 1. Gizlemeler (Teknik ID'ler)
                string[] gizli = { "KayitID", "KimdenID" };
                foreach (var s in gizli)
                    if (gridViewArkadaslar.Columns[s] != null) gridViewArkadaslar.Columns[s].Visible = false;

                // 2. ID SÜTUNU AYARLARI (Görünür Olsun)
                if (gridViewArkadaslar.Columns["ArkadasID"] != null)
                {
                    gridViewArkadaslar.Columns["ArkadasID"].Visible = true;
                    gridViewArkadaslar.Columns["ArkadasID"].Caption = "ID";
                    gridViewArkadaslar.Columns["ArkadasID"].Width = 30;
                    gridViewArkadaslar.Columns["ArkadasID"].VisibleIndex = 0; // En başa al
                }

                // 3. Genel Ayarlar
                gridViewArkadaslar.OptionsBehavior.Editable = false; // Salt okunur
                gridViewArkadaslar.BestFitColumns(); // Genişlikleri ayarla

                // 4. Ortalama Puanı Yıldız Olarak Göster
                if (gridViewArkadaslar.Columns["OrtalamaPuan"] != null)
                {
                    RepositoryItemRatingControl repoOrtalama = new RepositoryItemRatingControl();
                    repoOrtalama.ReadOnly = true;
                    gridArkadaslar.RepositoryItems.Add(repoOrtalama);
                    gridViewArkadaslar.Columns["OrtalamaPuan"].ColumnEdit = repoOrtalama;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste hatası: " + ex.Message);
            }
        }

        // --- 2. ÇİFT TIKLAMA İLE PROFİL AÇMA (GÜNCELLEME EKLENDİ) ---
        private void gridViewArkadaslar_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hitInfo = gridViewArkadaslar.CalcHitInfo(gridArkadaslar.PointToClient(Cursor.Position));

            if (hitInfo.InRow || hitInfo.InRowCell)
            {
                DataRow dr = gridViewArkadaslar.GetDataRow(hitInfo.RowHandle);
                if (dr != null)
                {
                    int arkadasId = Convert.ToInt32(dr["ArkadasID"]);

                    FrmProfil frm = new FrmProfil();
                    frm.GelenKullaniciID = arkadasId;

                    // MDI Parent ayarı (Eğer MDI kullanıyorsan)
                    // Not: ShowDialog kullanınca MDI Parent kullanılamaz, o yüzden kapattım.
                    // frm.MdiParent = this.MdiParent; 

                    // DÜZELTME: Show() yerine ShowDialog() kullanıyoruz.
                    // Böylece profil sayfası kapanana kadar buradaki kod bekler.
                    frm.ShowDialog();

                    // Profil kapandığı an bu kod çalışır ve listeyi günceller.
                    ArkadaslariListele();
                }
            }
        }

        // --- DİĞER METOTLAR (AYNEN KALIYOR) ---

        public void RandevulariYenile()
        {
            try
            {
                if (gridView1 != null)
                {
                    gridView1.OptionsView.ShowViewCaption = true;
                    gridView1.ViewCaption = "YAKLAŞAN MAÇLARIM";
                    gridView1.OptionsView.ShowGroupPanel = false;
                }

                string sorgu = @"
                    SELECT TOP 10 
                        s.TesisAdi + ' - ' + s.SahaTanimi as [Saha], 
                        r.Tarih, 
                        r.Saat 
                    FROM Randevular r
                    INNER JOIN Sahalar s ON r.SahaID = s.SahaID
                    WHERE r.UserId = @p1 AND r.Tarih >= CAST(GETDATE() AS DATE)
                    ORDER BY r.Tarih ASC, r.Saat ASC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
                da.SelectCommand.Parameters.AddWithValue("@p1", UserSession.UserId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridFikstur.DataSource = dt;

                if (gridView1 != null) gridView1.BestFitColumns();
            }
            catch { }
        }

        void GrafikGuncelle()
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select MacSayisi, GolSayisi From Users Where UserId=@p1", bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", UserSession.UserId);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    chartControl1.Series.Clear();
                    Series seri = new Series("Performans", ViewType.Bar);

                    int mac = dr["MacSayisi"] != DBNull.Value ? Convert.ToInt32(dr["MacSayisi"]) : 0;
                    int gol = dr["GolSayisi"] != DBNull.Value ? Convert.ToInt32(dr["GolSayisi"]) : 0;

                    double macBasinaGol = 0;
                    if (mac > 0) macBasinaGol = Math.Round((double)gol / mac, 2);

                    seri.Points.Add(new SeriesPoint("Oynanan Maç", mac));
                    seri.Points.Add(new SeriesPoint("Atılan Gol", gol));
                    seri.Points.Add(new SeriesPoint("Maç Başına Gol", macBasinaGol));

                    chartControl1.Series.Add(seri);
                    seri.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    chartControl1.AppearanceNameSerializable = "Chameleon";
                }
                bgl.Baglanti().Close();
            }
            catch { }
        }

        void ButonlariHazirla()
        {
            btnKabulEt = new RepositoryItemButtonEdit();
            btnKabulEt.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnKabulEt.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK;
            btnKabulEt.Buttons[0].Caption = "Kabul";
            btnKabulEt.ButtonClick += BtnKabulEt_ButtonClick;
            gridIstekler.RepositoryItems.Add(btnKabulEt);

            btnReddet = new RepositoryItemButtonEdit();
            btnReddet.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnReddet.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnReddet.Buttons[0].Caption = "Reddet";
            btnReddet.ButtonClick += BtnReddet_ButtonClick;
            gridIstekler.RepositoryItems.Add(btnReddet);
        }

        void AramaButonunuHazirla()
        {
            btnIstekGonder = new RepositoryItemButtonEdit();
            btnIstekGonder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnIstekGonder.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus;
            btnIstekGonder.Buttons[0].Caption = "Ekle";
            btnIstekGonder.ButtonClick += BtnIstekGonder_ButtonClick;

            if (gridViewAramaSonuclari != null && gridViewAramaSonuclari.Columns["IstekGonder"] != null)
            {
                gridViewAramaSonuclari.Columns["IstekGonder"].ColumnEdit = btnIstekGonder;
            }
        }

        void IstekleriListele()
        {
            try
            {
                string sorgu = @"
                    SELECT 
                        a.ID as [KayitID],
                        u.UserId as [KimdenID],
                        u.FullName as [İstek Gönderen],
                        'Kabul' as [Onay], 
                        'Red' as [Iptal]   
                    FROM Arkadaslar a
                    JOIN Users u ON a.KimdenID = u.UserId
                    WHERE a.KimeID = @p1 AND a.Durum = 0";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
                da.SelectCommand.Parameters.AddWithValue("@p1", UserSession.UserId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridIstekler.DataSource = dt;

                if (gridViewIstekler.Columns["KayitID"] != null) gridViewIstekler.Columns["KayitID"].Visible = false;
                if (gridViewIstekler.Columns["KimdenID"] != null) gridViewIstekler.Columns["KimdenID"].Visible = false;

                if (gridViewIstekler.Columns["Onay"] != null) gridViewIstekler.Columns["Onay"].ColumnEdit = btnKabulEt;
                if (gridViewIstekler.Columns["Iptal"] != null) gridViewIstekler.Columns["Iptal"].ColumnEdit = btnReddet;

                gridViewIstekler.BestFitColumns();
            }
            catch { }
        }

        // --- BUTON OLAYLARI (KABUL/RED/İSTEK) ---
        private void BtnKabulEt_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridViewIstekler.GetDataRow(gridViewIstekler.FocusedRowHandle);
            if (dr != null)
            {
                int kayitId = Convert.ToInt32(dr["KayitID"]);
                SqlCommand cmd = new SqlCommand("UPDATE Arkadaslar SET Durum=1 WHERE ID=@p1", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", kayitId);
                cmd.ExecuteNonQuery();
                bgl.Baglanti().Close();
                IstekleriListele();
                ArkadaslariListele();
            }
        }

        private void BtnReddet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridViewIstekler.GetDataRow(gridViewIstekler.FocusedRowHandle);
            if (dr != null)
            {
                int kayitId = Convert.ToInt32(dr["KayitID"]);
                SqlCommand cmd = new SqlCommand("DELETE FROM Arkadaslar WHERE ID=@p1", bgl.Baglanti());
                cmd.Parameters.AddWithValue("@p1", kayitId);
                cmd.ExecuteNonQuery();
                bgl.Baglanti().Close();
                IstekleriListele();
            }
        }

        private void BtnIstekGonder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridViewAramaSonuclari.GetDataRow(gridViewAramaSonuclari.FocusedRowHandle);
            if (dr != null)
            {
                if (MessageBox.Show(dr["AdSoyad"].ToString() + " kişisine istek gönderilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = bgl.Baglanti())
                        {
                            string sorgu = "INSERT INTO Arkadaslar (KimdenID, KimeID, Durum) VALUES (@p1, @p2, 0)";
                            SqlCommand cmd = new SqlCommand(sorgu, conn);
                            cmd.Parameters.AddWithValue("@p1", UserSession.UserId);
                            cmd.Parameters.AddWithValue("@p2", Convert.ToInt32(dr["UserId"]));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("İstek gönderildi!");
                        btnAra_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İstek gönderilemedi: " + ex.Message);
                    }
                }
            }
        }

        // --- SAĞ TIK MENÜSÜ ---
        private void gridArkadaslar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) cmsArkadas.Show(gridArkadaslar, e.Location);
        }

        private void arkadaşlıktanÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = gridViewArkadaslar.GetDataRow(gridViewArkadaslar.FocusedRowHandle);
            if (dr != null)
            {
                if (MessageBox.Show(dr["Arkadaş"].ToString() + " kişisi silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int kayitId = Convert.ToInt32(dr["KayitID"]);
                    SqlCommand cmd = new SqlCommand("DELETE FROM Arkadaslar WHERE ID=@p1", bgl.Baglanti());
                    cmd.Parameters.AddWithValue("@p1", kayitId);
                    cmd.ExecuteNonQuery();
                    bgl.Baglanti().Close();
                    ArkadaslariListele();
                }
            }
        }

        void EksikSkorKontrolu()
        {
            try
            {
                string sorgu = @"SELECT RandevuID, Tarih, Saat FROM Randevular WHERE UserId = @p1 AND MacSkoru IS NULL AND Durum = 1";
                using (SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti()))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p1", UserSession.UserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime macTarihi = Convert.ToDateTime(dr["Tarih"]);
                        string saatStr = dr["Saat"].ToString();
                        if (TimeSpan.TryParse(saatStr, out TimeSpan saatFarki)) macTarihi = macTarihi.Add(saatFarki);

                        if (macTarihi < DateTime.Now)
                        {
                            FrmSkorGiris frm = new FrmSkorGiris();
                            frm.GelenRandevuID = Convert.ToInt32(dr["RandevuID"]);
                            frm.GelenUserID = UserSession.UserId;
                            if (frm.ShowDialog() == DialogResult.OK) GrafikGuncelle();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"
                    SELECT 
                        UserId,
                        FullName as [AdSoyad],
                        Sehir,
                        Mevki,
                        ISNULL(CAST(ToplamPuan AS FLOAT) / NULLIF(OySayisi, 0), 0) as [OrtalamaPuan],
                        'Ekle' as [IstekGonder]
                    FROM Users
                    WHERE UserId != @ben
                    AND UserId NOT IN (
                        SELECT KimeID FROM Arkadaslar WHERE KimdenID = @ben 
                        UNION 
                        SELECT KimdenID FROM Arkadaslar WHERE KimeID = @ben
                    )
                ";

                if (!string.IsNullOrEmpty(txtArama.Text))
                    sql += " AND (FullName LIKE @metin OR CAST(UserId as nvarchar) = @metin2)";

                if (cmbSehirFiltre.SelectedIndex > 0 && cmbSehirFiltre.Text != "Tümü")
                    sql += " AND Sehir = @sehir";

                if (cmbMevkiFiltre.SelectedIndex > 0 && cmbMevkiFiltre.Text != "Tümü")
                    sql += " AND Mevki = @mevki";

                if (cmbPuanFiltre.SelectedIndex > 0 && cmbPuanFiltre.Text != "Farketmez")
                {
                    if (cmbPuanFiltre.Text.Contains("3")) sql += " AND (ISNULL(CAST(ToplamPuan AS FLOAT) / NULLIF(OySayisi, 0), 0)) >= 3";
                    else if (cmbPuanFiltre.Text.Contains("4")) sql += " AND (ISNULL(CAST(ToplamPuan AS FLOAT) / NULLIF(OySayisi, 0), 0)) >= 4";
                    else if (cmbPuanFiltre.Text.Contains("5")) sql += " AND (ISNULL(CAST(ToplamPuan AS FLOAT) / NULLIF(OySayisi, 0), 0)) >= 5";
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, bgl.Baglanti());
                da.SelectCommand.Parameters.AddWithValue("@ben", UserSession.UserId);

                if (!string.IsNullOrEmpty(txtArama.Text))
                {
                    da.SelectCommand.Parameters.AddWithValue("@metin", "%" + txtArama.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@metin2", txtArama.Text);
                }
                if (cmbSehirFiltre.SelectedIndex > 0 && cmbSehirFiltre.Text != "Tümü")
                    da.SelectCommand.Parameters.AddWithValue("@sehir", cmbSehirFiltre.Text);

                if (cmbMevkiFiltre.SelectedIndex > 0 && cmbMevkiFiltre.Text != "Tümü")
                    da.SelectCommand.Parameters.AddWithValue("@mevki", cmbMevkiFiltre.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                gridAramaSonuclari.DataSource = dt;

                gridViewAramaSonuclari.BestFitColumns();
                if (gridViewAramaSonuclari.Columns["UserId"] != null)
                    gridViewAramaSonuclari.Columns["UserId"].Visible = false;

                if (gridViewAramaSonuclari.Columns["IstekGonder"] != null)
                    gridViewAramaSonuclari.Columns["IstekGonder"].ColumnEdit = btnIstekGonder;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message);
            }
        }

        private void chartControl1_Click_1(object sender, EventArgs e) { }
    }
}