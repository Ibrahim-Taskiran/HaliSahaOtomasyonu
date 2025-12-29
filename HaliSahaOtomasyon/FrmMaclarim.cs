using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace HaliSahaOtomasyon
{
    public partial class FrmMaclarim : Form
    {
        public FrmMaclarim()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        // --- API AYARLARI ---
        private string apiKey = "3705be414d9346c2f1c9fdb07443cc07";
        private string apiAdres = "http://api.openweathermap.org/data/2.5/weather?q={0}&mode=xml&lang=tr&units=metric&appid={1}";

        // --- 1. LİSTEYİ DOLDURMA (SKOR SÜTUNU EKLENDİ) ---
        void ListeyiDoldur()
        {
            try
            {
                // GÜNCELLEME: Sorguya 'MacSkoru' alanı eklendi.
                // ISNULL(MacSkoru, '-') -> Skor girilmemişse tire koyar.
                // Manuel maçlarda skor sistemi olmadığı için direkt '-' dedik.

                string sorgu = @"
                    SELECT 
                        -1 * RandevuID as ID, 
                        Tarih, 
                        Saat, 
                        (TesisAdi + ' - ' + SahaTanimi) as Saha, 
                        'Uygulama' as [Kayıt Türü], 
                        'Sistem Kaydı' as [Maç Başlığı], 
                        '' as WebLinki,
                        ISNULL(MacSkoru, '-') as [Skor]
                    FROM Randevular r 
                    JOIN Sahalar s ON r.SahaID = s.SahaID 
                    WHERE r.UserId = @p1
                    
                    UNION ALL
                    
                    SELECT 
                        ID, 
                        Tarih, 
                        Saat, 
                        SahaAdi as Saha, 
                        'Manuel Eklendi' as [Kayıt Türü], 
                        Baslik as [Maç Başlığı], 
                        WebLinki,
                        '-' as [Skor]
                    FROM Maclarim 
                    WHERE UserId = @p1
                    ORDER BY Tarih DESC, Saat ASC";

                using (SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti()))
                {
                    da.SelectCommand.Parameters.AddWithValue("@p1", UserSession.UserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridMaclarim.DataSource = dt;
                }
                ModernGorsellikAyarla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste yüklenirken hata oluştu: " + ex.Message);
            }
        }

        // --- 2. MODERN GÖRÜNÜM AYARLARI (SKOR ORTALAMA EKLENDİ) ---
        void ModernGorsellikAyarla()
        {
            var view = gridMaclarim.MainView as GridView;
            if (view != null)
            {
                if (view.Columns["ID"] != null) view.Columns["ID"].Visible = false;
                if (view.Columns["WebLinki"] != null) view.Columns["WebLinki"].Visible = false;

                view.RowHeight = 40;
                view.Appearance.Row.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                view.Appearance.HeaderPanel.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                view.OptionsView.EnableAppearanceEvenRow = true;
                view.Appearance.EvenRow.BackColor = Color.AliceBlue;

                view.BestFitColumns();
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsBehavior.Editable = false;

                // SKOR SÜTUNUNU ORTALA
                if (view.Columns["Skor"] != null)
                {
                    view.Columns["Skor"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    view.Columns["Skor"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }

        // --- 3. SAĞ TIK: SİLME İŞLEMİ ---
        private void mnuSil_Click(object sender, EventArgs e)
        {
            var view = gridMaclarim.MainView as GridView;
            if (view.GetFocusedDataRow() == null) return;

            int id = Convert.ToInt32(view.GetFocusedRowCellValue("ID"));
            string kayitTuru = view.GetFocusedRowCellValue("Kayıt Türü").ToString();

            if (kayitTuru != "Manuel Eklendi")
            {
                MessageBox.Show("Sistem randevuları buradan silinemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bu maçı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = bgl.Baglanti())
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM Maclarim WHERE ID = @p1", conn);
                        cmd.Parameters.AddWithValue("@p1", id);
                        cmd.ExecuteNonQuery();
                    }
                    ListeyiDoldur();
                    IstatistikleriGuncelle();
                }
                catch (Exception ex) { MessageBox.Show("Silme hatası: " + ex.Message); }
            }
        }

        // --- 4. SAĞ TIK: LİNK EKLEME/DÜZENLEME ---
        private void mnuLinkEkle_Click(object sender, EventArgs e)
        {
            var view = gridMaclarim.MainView as GridView;
            if (view.GetFocusedDataRow() == null) return;

            int id = Convert.ToInt32(view.GetFocusedRowCellValue("ID"));
            string kayitTuru = view.GetFocusedRowCellValue("Kayıt Türü").ToString();

            string saha = view.GetFocusedRowCellValue("Saha")?.ToString();
            string saat = view.GetFocusedRowCellValue("Saat")?.ToString();
            string baslik = view.GetFocusedRowCellValue("Maç Başlığı")?.ToString();
            string link = view.GetFocusedRowCellValue("WebLinki")?.ToString();
            string tarihStr = view.GetFocusedRowCellValue("Tarih")?.ToString();

            FrmMacEkle frm = new FrmMacEkle();

            if (kayitTuru == "Manuel Eklendi")
                frm.GelenId = id;
            else
                frm.GelenId = 0;

            frm.GelenSaha = saha;
            frm.GelenSaat = saat;
            frm.GelenTarih = tarihStr;
            frm.GelenBaslik = (kayitTuru == "Manuel Eklendi") ? baslik : "";
            frm.GelenLink = link;

            frm.ShowDialog();

            ListeyiDoldur();
            IstatistikleriGuncelle();
        }

        // --- İSTATİSTİKLER ---
        void IstatistikleriGuncelle()
        {
            var gridView = gridMaclarim.MainView as GridView;
            if (gridView == null) return;
            int toplamMac = gridView.RowCount;

            // 1. Toplam Maç
            if (tileToplamMac != null)
            {
                KutuYaz(tileToplamMac, "Toplam Maç", toplamMac.ToString());
            }

            // 2. Hava Durumu
            if (tileHavaDurumu != null)
            {
                string sehir = UserSession.Sehir;
                if (string.IsNullOrEmpty(sehir)) sehir = "Elazığ";
                string sicaklik = HavaDurumuGetir(sehir);

                KutuYaz(tileHavaDurumu, sehir + " Havası", sicaklik);
            }

            // 3. Sıradaki Maç
            if (tileSiradakiMac != null)
            {
                string sorgu = @"SELECT TOP 1 Tarih, Saat FROM (
                    SELECT Tarih, Saat FROM Randevular WHERE UserId=@p1 AND Tarih >= CAST(GETDATE() AS DATE)
                    UNION ALL
                    SELECT Tarih, Saat FROM Maclarim WHERE UserId=@p1 AND Tarih >= CAST(GETDATE() AS DATE)
                ) as TumMaclar ORDER BY Tarih ASC, Saat ASC";

                using (SqlConnection conn = bgl.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", UserSession.UserId);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        DateTime macTarihi = Convert.ToDateTime(dr["Tarih"]);
                        string saatStr = dr["Saat"].ToString();
                        if (TimeSpan.TryParse(saatStr, out TimeSpan saatFarki)) macTarihi = macTarihi.Add(saatFarki);

                        KutuYaz(tileSiradakiMac, "Sıradaki Maç", macTarihi.ToString("dd MMM - HH:mm"));
                    }
                    else
                    {
                        KutuYaz(tileSiradakiMac, "Sıradaki Maç", "Yok");
                    }
                }
            }
        }

        // --- HAVA DURUMU API ---
        public string HavaDurumuGetir(string sehir)
        {
            try
            {
                string istekAdresi = string.Format(apiAdres, sehir, apiKey);
                XDocument havaDurumu = XDocument.Load(istekAdresi);
                var sicaklikDegeri = havaDurumu.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                double derece = Convert.ToDouble(sicaklikDegeri.Replace('.', ','));
                return Math.Round(derece).ToString() + "°C";
            }
            catch
            {
                return "--°C";
            }
        }

        // --- KUTU YAZDIRMA ---
        void KutuYaz(TileItem kutu, string baslik, string deger)
        {
            if (kutu == null) return;

            kutu.Elements.Clear();
            kutu.Frames.Clear();

            // Başlık
            TileItemElement baslikElemani = new TileItemElement();
            baslikElemani.Text = baslik;
            baslikElemani.TextAlignment = TileItemContentAlignment.TopLeft;
            baslikElemani.Appearance.Normal.FontSizeDelta = -1;
            kutu.Elements.Add(baslikElemani);

            // Değer
            TileItemElement degerElemani = new TileItemElement();
            degerElemani.Text = deger;
            degerElemani.TextAlignment = TileItemContentAlignment.MiddleCenter;
            degerElemani.Appearance.Normal.FontSizeDelta = 4;
            degerElemani.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
            kutu.Elements.Add(degerElemani);
        }

        private void FrmMaclarim_Load(object sender, EventArgs e)
        {
            gridMaclarim.ContextMenuStrip = contextMenuStrip1;
            ListeyiDoldur();
            IstatistikleriGuncelle();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            FrmMacEkle frm = new FrmMacEkle();
            frm.ShowDialog();
            ListeyiDoldur();
            IstatistikleriGuncelle();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            ListeyiDoldur();
            IstatistikleriGuncelle();
        }

        // --- VİDEO İZLEME ---
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            string link = view.GetFocusedRowCellValue("WebLinki")?.ToString();

            if (!string.IsNullOrEmpty(link))
            {
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = link, UseShellExecute = true }); }
                catch { MessageBox.Show("Link açılamadı."); }
            }
            else
            {
                MessageBox.Show("Video linki yok. Sağ tıklayıp 'Link Ekle' diyerek ekleyebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- SAĞ TIK MENÜSÜ ---
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}