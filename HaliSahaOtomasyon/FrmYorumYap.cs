using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors; // DevExpress kütüphanesi

namespace HaliSahaOtomasyon
{
    public partial class FrmYorumYap : Form
    {
        // SQL Bağlantı sınıfımız
        SqlBaglantisi bgl = new SqlBaglantisi();

        // Diğer formdan (RandevuAl) buraya SahaID gelecek
        public int SahaID = 0;

        public FrmYorumYap()
        {
            InitializeComponent();

            // --- FORM AYARLARI (Kod ile otomatik yapılır) ---
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında aç
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Sadece kapat tuşu olsun
            this.Text = "Puan Ver ve Yorumla";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(250, 250);
        }

        // --- YARDIMCI METOT: Geçmiş Randevu ID'sini Bul ---
        // Yorumun veritabanına kaydedilmesi için bir RandevuID'ye ihtiyacı var.
        // Bu metot, kullanıcının o sahadaki EN SON maçını bulur.
        int SonMacRandevuIDGetir()
        {
            int randevuId = 0;

            // Sorgu: Bu sahada, bu kullanıcının, bugünden önceki en son randevusu
            string sorgu = @"
                SELECT TOP 1 RandevuID 
                FROM Randevular 
                WHERE SahaID=@p1 
                AND UserId=@p2 
                AND Tarih < CAST(GETDATE() AS DATE)
                ORDER BY Tarih DESC";

            using (SqlConnection conn = bgl.Baglanti())
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@p1", SahaID);
                cmd.Parameters.AddWithValue("@p2", UserSession.UserId);

                object sonuc = cmd.ExecuteScalar();
                if (sonuc != null)
                {
                    randevuId = Convert.ToInt32(sonuc);
                }
            }
            return randevuId;
        }

        // --- GÖNDER BUTONU ---
        private void btnGonder_Click(object sender, EventArgs e)
        {
            // 1. DevExpress Rating Kontrolünden Puanı Al
            // ratingPuan.Rating bize 'decimal' (örn: 4.0) verir, bunu tam sayıya (int) çeviriyoruz.
            int puan = (int)ratingPuan.Rating;

            // Kontroller
            if (puan == 0)
            {
                MessageBox.Show("Lütfen yıldızlara tıklayarak bir puan veriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYorum.Text))
            {
                MessageBox.Show("Lütfen yorumunuzu yazınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Randevu ID'sini bul
            int randevuId = SonMacRandevuIDGetir();

            if (randevuId == 0)
            {
                MessageBox.Show("Hata: Bu sahada geçmiş tarihli bir maç kaydınız bulunamadı.\nYorum yapmak için maçın tamamlanmış olması gerekir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Veritabanına Kaydet
            try
            {
                string insertSorgu = @"
                    INSERT INTO Yorumlar (RandevuID, Puan, YorumMetni, Tarih) 
                    VALUES (@p1, @p2, @p3, @p4)";

                using (SqlConnection conn = bgl.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(insertSorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", randevuId);
                    cmd.Parameters.AddWithValue("@p2", puan);
                    cmd.Parameters.AddWithValue("@p3", txtYorum.Text); // MemoEdit'in içeriği
                    cmd.Parameters.AddWithValue("@p4", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Değerli yorumunuz kaydedildi. Teşekkür ederiz!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu kapat, kullanıcı listeyi görsün
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yorum kaydedilirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}