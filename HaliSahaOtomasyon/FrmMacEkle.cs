using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace HaliSahaOtomasyon
{
    public partial class FrmMacEkle : Form
    {
        public FrmMacEkle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        // --- DIŞARIDAN GELECEK VERİLER İÇİN DEĞİŞKENLER ---
        public int GelenId = 0;       // 0 ise Yeni Kayıt, 0'dan büyükse Düzenleme
        public string GelenSaha;
        public string GelenTarih;
        public string GelenSaat;
        public string GelenBaslik;
        public string GelenLink;

        // --- FORM YÜKLENİRKEN (LOAD) ---
        

        // --- 1. MAÇI BUL (SİTEYE GİT) ---
        private void btnBul_Click(object sender, EventArgs e)
        {
            string saha = txtSaha.Text.Trim();
            string tarih = dtTarih.Value.ToString("dd.MM.yyyy");
            string saat = txtSaat.Text.Trim();

            if (saha == "" || saat == "")
            {
                MessageBox.Show("Saha ve Saat bilgileri boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hedefLink = "https://sosyalhalisaha.com/mac-videolari";
            try
            {
                Process.Start(new ProcessStartInfo { FileName = hedefLink, UseShellExecute = true });
                MessageBox.Show(
                    $"Tarayıcı açıldı!\n\nSitede şu bilgileri aratın:\n" +
                    $"🏟️ Saha: {saha}\n📅 Tarih: {tarih}\n⏰ Saat: {saat}\n\n" +
                    "Sonra linki kopyalayıp buraya yapıştırın.",
                    "Yönlendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarayıcı hatası: " + ex.Message);
            }
        }

        // --- 2. KAYDET / GÜNCELLE BUTONU ---
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBaslik.Text.Trim() == "" || txtLink.Text.Trim() == "")
            {
                MessageBox.Show("Başlık ve Link alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    // SENARYO 1: YENİ KAYIT (INSERT)
                    if (GelenId == 0)
                    {
                        string sorgu = "INSERT INTO Maclarim (UserId, Tarih, Saat, SahaAdi, WebLinki, Baslik) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                        SqlCommand cmd = new SqlCommand(sorgu, conn);
                        cmd.Parameters.AddWithValue("@p1", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@p2", dtTarih.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@p3", txtSaat.Text);
                        cmd.Parameters.AddWithValue("@p4", txtSaha.Text);
                        cmd.Parameters.AddWithValue("@p5", txtLink.Text);
                        cmd.Parameters.AddWithValue("@p6", txtBaslik.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Maç başarıyla eklendi!", "Bilgi");
                    }
                    // SENARYO 2: GÜNCELLEME (UPDATE) -> LİNK EKLEME BURADA
                    else
                    {
                        string sorgu = "UPDATE Maclarim SET WebLinki=@p1, Baslik=@p2, SahaAdi=@p3, Saat=@p4, Tarih=@p5 WHERE ID=@p6";
                        SqlCommand cmd = new SqlCommand(sorgu, conn);
                        cmd.Parameters.AddWithValue("@p1", txtLink.Text);
                        cmd.Parameters.AddWithValue("@p2", txtBaslik.Text);
                        cmd.Parameters.AddWithValue("@p3", txtSaha.Text); // Belki sahayı yanlış girmişti, düzeltmesine izin verelim
                        cmd.Parameters.AddWithValue("@p4", txtSaat.Text);
                        cmd.Parameters.AddWithValue("@p5", dtTarih.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@p6", GelenId); // Hangi kaydı güncelleyeceğimizi ID ile biliyoruz
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Video linki ve bilgiler güncellendi!", "Başarılı");
                    }
                }
                this.Close(); // İşlem bitince formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void FrmMacEkle_Load_1(object sender, EventArgs e)
        {
            // 1. Önce gönderilen verileri kutulara dolduralım (ID'den bağımsız olarak!)
            // Böylece hem düzenlemede hem de sistem kaydından link eklerken veriler gelir.
            txtSaha.Text = GelenSaha;
            txtSaat.Text = GelenSaat;
            txtBaslik.Text = GelenBaslik;
            txtLink.Text = GelenLink;

            if (DateTime.TryParse(GelenTarih, out DateTime tarih))
            {
                dtTarih.Value = tarih;
            }

            // 2. Şimdi Modu Belirleyelim (Görünüm Ayarları)
            if (GelenId > 0)
            {
                // Düzenleme Modu (Var olan kaydı güncelliyoruz)
                this.Text = "Maç Düzenle";
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                // Yeni Kayıt Modu
                // Eğer saha bilgisi dolu geldiyse (Sistem kaydından link ekliyorsak)
                if (!string.IsNullOrEmpty(GelenSaha))
                {
                    this.Text = "Sistem Kaydına Link Ekle";
                    btnKaydet.Text = "Kaydet";
                }
                else
                {
                    // Sıfırdan elle maç ekliyorsak
                    this.Text = "Yeni Maç Ekle";
                    btnKaydet.Text = "Kaydet";
                }
            }
        }
    }
}