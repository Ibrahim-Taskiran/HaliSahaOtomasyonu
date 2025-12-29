using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSahaOtomasyon
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnKayit01_Click(object sender, EventArgs e)
        {
            FrmKayit fr = new FrmKayit();
            fr.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlBaglantisi bgl = new SqlBaglantisi();

            // 2. Kullanıcıyı sorgula (Email ve Şifre ile)
            SqlCommand komut = new SqlCommand("Select * From Users where Email=@p1 and Password=@p2", bgl.Baglanti());

            // 3. Parametreleri kutulardan al
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            // 4. Okuma işlemi
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                // --- GİRİŞ BAŞARILI ---

                // Veritabanından isim ve ID bilgisini çek
                string gelenAdSoyad = dr["FullName"].ToString();
                int gelenId = Convert.ToInt32(dr["UserId"]);

                // !!! KRİTİK ADIM: GLOBAL OTURUM BİLGİLERİNİ KAYDET !!!
                // Artık projenin her yerinden UserSession.UserId diyerek bu ID'ye ulaşabilirsin.
                UserSession.UserId = gelenId;
                UserSession.AdSoyad = gelenAdSoyad;
                UserSession.Sehir = dr["Sehir"].ToString();
                UserSession.Mevki = dr["Mevki"].ToString();

                // Ana Modülü oluştur
                FrmAnaModul fr = new FrmAnaModul();

                // Sağ üstteki yazıyı güncellemek için bilgiyi oraya da gönderiyoruz
                fr.KullaniciBilgisiAl(gelenAdSoyad, gelenId);

                // Ana Formu aç, Giriş formunu gizle
                fr.Show();
                this.Hide();
            }
            else
            {
                // --- GİRİŞ BAŞARISIZ ---
                MessageBox.Show("Hatalı E-Posta veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Bağlantıyı kapat
            bgl.Baglanti().Close();

        }

        
        // FrmGiris.cs -> FormClosed Olayı
        private void FrmGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Giriş formu tamamen kapatıldığında (çarpıya basılınca) tüm uygulamayı bitir.
            Application.Exit();
        }
    }
}