using HalisahaOtomasyonu;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSahaOtomasyon
{
    public partial class FrmRandevuAl : Form
    {
        // ASYNC ÇAKIŞMA ÖNLEYİCİ SAYAÇ
        private long _islemSayaci = 0;

        public FrmRandevuAl()
        {
            InitializeComponent();
            TarayiciVersiyonunuGuncelle();

            // Tüm eventleri Load metodunda bağlıyoruz.
            this.Load += FrmRandevuAl_Load;
        }

        public int gelenSahaID = 0;
        SqlBaglantisi bgl = new SqlBaglantisi();
        WeatherForecastRoot _cachedWeatherData;
        string _lastFetchedDate = "";

        private void TarayiciVersiyonunuGuncelle()
        {
            try
            {
                string appName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                RegistryKey featureControlRegKey = Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (featureControlRegKey != null)
                {
                    featureControlRegKey.SetValue(appName, 11001, RegistryValueKind.DWord);
                    featureControlRegKey.Close();
                }
            }
            catch { }
        }

        void SahalariGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select SahaID, (TesisAdi + ' - ' + SahaTanimi) as Ad From Sahalar", bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbSahalar.ValueMember = "SahaID";
            cmbSahalar.DisplayMember = "Ad";
            cmbSahalar.DataSource = dt;
        }

        void GecmisRandevularimiListele()
        {
            int girisYapanKullaniciID = UserSession.UserId;
            string sorgu = @"SELECT s.TesisAdi + ' ' + s.SahaTanimi as [Saha], r.Tarih, r.Saat FROM Randevular r JOIN Sahalar s ON r.SahaID = s.SahaID WHERE r.UserId = " + girisYapanKullaniciID;
            SqlDataAdapter da = new SqlDataAdapter(sorgu, bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SahaDetaylariniGetir(int sahaId)
        {
            // 1. HARİTA
            string enlem = "", boylam = "";
            wbHarita.ScriptErrorsSuppressed = true;

            OrtalamaPuanGetir(sahaId);

            SqlCommand cmdKonum = new SqlCommand("Select Enlem, Boylam From Sahalar Where SahaID=@p1", bgl.Baglanti());
            cmdKonum.Parameters.AddWithValue("@p1", sahaId);
            SqlDataReader dr = cmdKonum.ExecuteReader();
            if (dr.Read())
            {
                if (dr["Enlem"] != DBNull.Value) enlem = dr["Enlem"].ToString();
                if (dr["Boylam"] != DBNull.Value) boylam = dr["Boylam"].ToString();
            }
            dr.Close();
            bgl.Baglanti().Close();

            if (!string.IsNullOrEmpty(enlem) && !string.IsNullOrEmpty(boylam))
            {
                string lat = enlem.Replace(",", ".");
                string lon = boylam.Replace(",", ".");
                string link = $"https://static-maps.yandex.ru/1.x/?ll={lon},{lat}&z=14&l=map&pt={lon},{lat},pm2rdm";
                wbHarita.Navigate(link);
            }
            else
            {
                wbHarita.Navigate("about:blank");
            }

            // 2. RESİM
            pbSahaResim.Image = null;
            SqlCommand cmdResim = new SqlCommand("Select Top 1 DosyaYolu From SahaResimleri Where SahaID=@p1", bgl.Baglanti());
            cmdResim.Parameters.AddWithValue("@p1", sahaId);
            SqlDataReader drResim = cmdResim.ExecuteReader();
            if (drResim.Read())
            {
                string dbYol = drResim["DosyaYolu"].ToString();
                string tamYol = "";
                string yol1 = Path.Combine(Application.StartupPath, dbYol);
                string yol2 = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, dbYol);

                if (File.Exists(yol1)) tamYol = yol1;
                else if (File.Exists(yol2)) tamYol = yol2;

                if (!string.IsNullOrEmpty(tamYol) && File.Exists(tamYol))
                {
                    pbSahaResim.Image = Image.FromFile(tamYol);
                    pbSahaResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                }
            }
            drResim.Close();
            bgl.Baglanti().Close();

            // 3. YORUMLAR
            string yorumSorgusu = @"
                SELECT 
                    y.YorumID, 
                    r.Tarih, 
                    y.Puan, 
                    y.YorumMetni as 'Yorum',
                    r.UserId 
                FROM Yorumlar y 
                JOIN Randevular r ON y.RandevuID = r.RandevuID 
                WHERE r.SahaID = @p1 
                ORDER BY 
                    CASE WHEN r.UserId = @p2 THEN 0 ELSE 1 END, 
                    r.Tarih DESC";

            SqlDataAdapter daYorum = new SqlDataAdapter(yorumSorgusu, bgl.Baglanti());
            daYorum.SelectCommand.Parameters.AddWithValue("@p1", sahaId);
            daYorum.SelectCommand.Parameters.AddWithValue("@p2", UserSession.UserId);

            DataTable dtYorum = new DataTable();
            daYorum.Fill(dtYorum);
            gridYorumlar.DataSource = dtYorum;

            if (gridYorumlar.Columns.Contains("UserId")) gridYorumlar.Columns["UserId"].Visible = false;
            if (gridYorumlar.Columns.Contains("YorumID")) gridYorumlar.Columns["YorumID"].Visible = false;

            if (gridYorumlar.Columns.Count > 0)
            {
                if (gridYorumlar.Columns.Contains("Tarih")) gridYorumlar.Columns["Tarih"].Width = 70;
                if (gridYorumlar.Columns.Contains("Puan")) gridYorumlar.Columns["Puan"].Width = 40;
                if (gridYorumlar.Columns.Contains("Yorum")) gridYorumlar.Columns["Yorum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        // --- SAATLERİ OLUŞTUR ---
        async void SaatleriOlustur()
        {
            _islemSayaci++;
            long buIsleminNumarasi = _islemSayaci;

            flowLayoutPanel1.Controls.Clear();

            if (cmbSahalar.SelectedValue == null) return;
            int secilenId;
            if (!int.TryParse(cmbSahalar.SelectedValue.ToString(), out secilenId)) return;

            SahaDetaylariniGetir(secilenId);

            string secilenEnlem = "", secilenBoylam = "";
            SqlConnection connKonum = bgl.Baglanti();
            SqlCommand cmdKonum = new SqlCommand("Select Enlem, Boylam From Sahalar Where SahaID=@p1", connKonum);
            cmdKonum.Parameters.AddWithValue("@p1", secilenId);
            SqlDataReader drKonum = cmdKonum.ExecuteReader();
            if (drKonum.Read())
            {
                if (drKonum["Enlem"] != DBNull.Value) secilenEnlem = drKonum["Enlem"].ToString();
                if (drKonum["Boylam"] != DBNull.Value) secilenBoylam = drKonum["Boylam"].ToString();
            }
            drKonum.Close();
            connKonum.Close();

            string secilenTarihStr = dtTarih.Value.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(secilenEnlem) && !string.IsNullOrEmpty(secilenBoylam))
            {
                if (_cachedWeatherData == null || _lastFetchedDate != secilenTarihStr)
                {
                    WeatherService ws = new WeatherService();
                    _cachedWeatherData = await ws.GetHavaDurumuTahmini(secilenEnlem, secilenBoylam);
                    _lastFetchedDate = secilenTarihStr;
                }
            }
            else _cachedWeatherData = null;

            if (buIsleminNumarasi != _islemSayaci) return;

            flowLayoutPanel1.Controls.Clear();

            SqlConnection conn = bgl.Baglanti();
            for (int i = 10; i < 24; i++)
            {
                Button btn = new Button();
                string saatMetni = i + ":00";
                DateTime butonZamani = new DateTime(dtTarih.Value.Year, dtTarih.Value.Month, dtTarih.Value.Day, i, 0, 0);

                btn.Width = 110; btn.Height = 85; btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 1;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold); btn.Margin = new Padding(5);
                btn.TextAlign = ContentAlignment.BottomCenter; btn.ImageAlign = ContentAlignment.TopCenter;
                btn.Text = saatMetni;

                if (butonZamani < DateTime.Now)
                {
                    // GEÇMİŞ ZAMAN
                    btn.BackColor = Color.Gainsboro;
                    btn.ForeColor = Color.SlateGray;
                    btn.FlatAppearance.BorderColor = Color.LightGray;
                    btn.Enabled = false;

                    SqlCommand cmdSkor = new SqlCommand("SELECT MacSkoru FROM Randevular WHERE SahaID=@p1 AND Tarih=@p2 AND Saat=@p3 AND Durum=1", conn);
                    cmdSkor.Parameters.AddWithValue("@p1", secilenId);
                    cmdSkor.Parameters.AddWithValue("@p2", dtTarih.Value.ToString("yyyy-MM-dd"));
                    cmdSkor.Parameters.AddWithValue("@p3", saatMetni);

                    object skorSonuc = cmdSkor.ExecuteScalar();

                    if (skorSonuc != null && skorSonuc != DBNull.Value)
                    {
                        btn.Text = $"{saatMetni}\n{skorSonuc}";
                        btn.BackColor = Color.LightSteelBlue;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.Text = $"{saatMetni}\nSüre Doldu";
                    }
                }
                else
                {
                    // GELECEK ZAMAN
                    SqlCommand komut = new SqlCommand("Select UserId From Randevular where SahaID=@p1 and Tarih=@p2 and Saat=@p3 and Durum=1", conn);
                    komut.Parameters.AddWithValue("@p1", secilenId);
                    komut.Parameters.AddWithValue("@p2", dtTarih.Value.ToString("yyyy-MM-dd"));
                    komut.Parameters.AddWithValue("@p3", saatMetni);
                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        int randevuSahibiID = Convert.ToInt32(dr["UserId"]);
                        if (randevuSahibiID == UserSession.UserId) { btn.BackColor = Color.Orange; btn.ForeColor = Color.White; btn.Text = $"{saatMetni}\nSİZİN\nRANDEVUNUZ"; btn.Enabled = false; }
                        else { btn.BackColor = Color.Firebrick; btn.ForeColor = Color.White; btn.Text = $"{saatMetni}\nDOLU"; btn.Enabled = false; }
                    }
                    else
                    {
                        btn.BackColor = Color.LightGreen; btn.ForeColor = Color.Black;
                        if (_cachedWeatherData != null)
                        {
                            var havaTahmini = _cachedWeatherData.list.OrderBy(x => Math.Abs((DateTime.Parse(x.dt_txt) - butonZamani).TotalMinutes)).FirstOrDefault();
                            if (havaTahmini != null && Math.Abs((DateTime.Parse(havaTahmini.dt_txt) - butonZamani).TotalHours) < 4)
                            {
                                string sicaklik = havaTahmini.main.temp.ToString("0") + "°C";
                                string iconCode = havaTahmini.weather[0].icon;
                                btn.Text = $"{saatMetni}\n{sicaklik}\nBOŞ";
                                btn.Image = ResimIndir($"http://openweathermap.org/img/wn/{iconCode}.png");
                            }
                            else btn.Text += "\nBOŞ";
                        }
                        else btn.Text += "\nBOŞ";

                        // Olayı bağlıyoruz
                        btn.Click += Btn_Click;
                    }
                    dr.Close();
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
            conn.Close();
        }

        private Image ResimIndir(string url)
        {
            try { using (WebClient wc = new WebClient()) { byte[] bytes = wc.DownloadData(url); using (MemoryStream ms = new MemoryStream(bytes)) { return Image.FromStream(ms); } } } catch { return null; }
        }

        // --- BUTONA TIKLANINCA (YENİ VE ÖNEMLİ KISIM) ---
        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            string secilenSaat = tiklananButon.Text.Split('\n')[0];
            int secilenSahaId = Convert.ToInt32(cmbSahalar.SelectedValue);

            // 1. KADRO OLUŞTURMA FORMUNU AÇ
            // Randevuyu ve kadroyu artık bu form kaydedecek.
            FrmKadroOlustur frm = new FrmKadroOlustur();
            frm.SecilenSahaID = secilenSahaId;
            frm.SecilenTarih = dtTarih.Value.ToString("yyyy-MM-dd");
            frm.SecilenSaat = secilenSaat;

            // 2. KULLANICI ONAYLARSA LİSTELERİ YENİLE
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Anasayfadaki listeyi yenile
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(FrmAnasayfa))
                    {
                        try { dynamic anasayfa = form; anasayfa.RandevulariYenile(); } catch { }
                    }
                }

                // Bu formdaki listeleri yenile
                GecmisRandevularimiListele();
                SaatleriOlustur(); // Butonu kırmızıya çevir
            }
        }

        private void FrmRandevuAl_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            SahalariGetir();
            if (gelenSahaID > 0) cmbSahalar.SelectedValue = gelenSahaID;
            GecmisRandevularimiListele();

            SaatleriOlustur();

            // Eventleri bağla
            cmbSahalar.SelectedIndexChanged += cmbSahalar_SelectedIndexChanged;
            dtTarih.ValueChanged += dtTarih_ValueChanged;
            gridYorumlar.MouseClick += gridYorumlar_MouseClick;
        }

        private void cmbSahalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaatleriOlustur();
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            SaatleriOlustur();
        }

        void OrtalamaPuanGetir(int sahaId)
        {
            string sorgu = @"
                SELECT ISNULL(AVG(CAST(y.Puan AS FLOAT)), 0) 
                FROM Yorumlar y
                JOIN Randevular r ON y.RandevuID = r.RandevuID
                WHERE r.SahaID = @p1";

            using (SqlConnection conn = bgl.Baglanti())
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@p1", sahaId);
                object sonuc = cmd.ExecuteScalar();
                decimal ortalama = Convert.ToDecimal(sonuc);

                ratingOrtalama.Rating = ortalama;
                lblOrtalama.Text = ortalama.ToString("0.0");

                if (ortalama >= 4) lblOrtalama.ForeColor = Color.Green;
                else if (ortalama >= 2.5m) lblOrtalama.ForeColor = Color.Orange;
                else lblOrtalama.ForeColor = Color.Red;
            }
        }

        bool YorumYapabilirMi(int sahaId, int userId)
        {
            bool sonuc = false;
            string sorgu = @"
                SELECT COUNT(*) 
                FROM Randevular 
                WHERE SahaID = @p1 
                AND UserId = @p2 
                AND Tarih < CAST(GETDATE() AS DATE)";

            using (SqlConnection baglanti = bgl.Baglanti())
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", sahaId);
                komut.Parameters.AddWithValue("@p2", userId);
                int gecmisMacSayisi = (int)komut.ExecuteScalar();
                if (gecmisMacSayisi > 0) sonuc = true;
            }
            return sonuc;
        }

        private void btnYorumYap_Click(object sender, EventArgs e)
        {
            if (cmbSahalar.SelectedValue == null) return;
            int secilenSahaId = Convert.ToInt32(cmbSahalar.SelectedValue);

            if (YorumYapabilirMi(secilenSahaId, UserSession.UserId))
            {
                FrmYorumYap frm = new FrmYorumYap();
                frm.SahaID = secilenSahaId;
                frm.ShowDialog();
                SahaDetaylariniGetir(secilenSahaId);
            }
            else
            {
                MessageBox.Show("Bu sahaya yorum yapabilmek için daha önce burada maç yapmış olmanız gerekmektedir.",
                                "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridYorumlar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = gridYorumlar.HitTest(e.X, e.Y);
                int currentMouseOverRow = hti.RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    gridYorumlar.ClearSelection();
                    gridYorumlar.Rows[currentMouseOverRow].Selected = true;

                    if (gridYorumlar.Rows[currentMouseOverRow].Cells["UserId"].Value != null)
                    {
                        int yorumSahibiID = Convert.ToInt32(gridYorumlar.Rows[currentMouseOverRow].Cells["UserId"].Value);
                        if (yorumSahibiID == UserSession.UserId)
                        {
                            cmsYorumIslemleri.Show(Cursor.Position);
                        }
                    }
                }
            }
        }

        private void yorumuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridYorumlar.SelectedRows.Count > 0)
            {
                int yorumId = Convert.ToInt32(gridYorumlar.SelectedRows[0].Cells["YorumID"].Value);
                if (MessageBox.Show("Bu yorumu silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = bgl.Baglanti())
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM Yorumlar WHERE YorumID = @p1", conn);
                            cmd.Parameters.AddWithValue("@p1", yorumId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Yorum silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cmbSahalar.SelectedValue != null)
                            SahaDetaylariniGetir(Convert.ToInt32(cmbSahalar.SelectedValue));
                    }
                    catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                }
            }
        }

        private void yorumuDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridYorumlar.SelectedRows.Count > 0)
            {
                int yorumId = Convert.ToInt32(gridYorumlar.SelectedRows[0].Cells["YorumID"].Value);
                int secilenSahaId = Convert.ToInt32(cmbSahalar.SelectedValue);

                if (MessageBox.Show("Yorumunuzu düzenlemek için:\n1. Mevcut yorumunuz silinecek.\n2. Yorum yapma ekranı açılacak.\n\nDevam etmek istiyor musunuz?", "Düzenle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = bgl.Baglanti())
                        {
                            SqlCommand cmd = new SqlCommand("DELETE FROM Yorumlar WHERE YorumID = @p1", conn);
                            cmd.Parameters.AddWithValue("@p1", yorumId);
                            cmd.ExecuteNonQuery();
                        }
                        FrmYorumYap frm = new FrmYorumYap();
                        frm.SahaID = secilenSahaId;
                        frm.ShowDialog();
                        SahaDetaylariniGetir(secilenSahaId);
                    }
                    catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                }
            }
        }

        private void cmsYorumIslemleri_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void gridYorumlar_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}