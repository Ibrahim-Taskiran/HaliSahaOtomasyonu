using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HaliSahaOtomasyon
{
    public partial class FrmSkorGiris : Form
    {
        public FrmSkorGiris()
        {
            InitializeComponent();
        }

        // Bağlantı sınıfı
        SqlBaglantisi bgl = new SqlBaglantisi();

        // BU DEĞİŞKENLER DIŞARIDAN (ANA MODÜLDEN) GELECEK
        public int GelenRandevuID = 0;
        public int GelenUserID = 0;

        private void FrmSkorGiris_Load(object sender, EventArgs e)
        {
            // Form yüklenirken imleç direkt skor kutusunda olsun
            txtSkor.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. BOŞ ALAN KONTROLÜ
            if (string.IsNullOrWhiteSpace(txtSkor.Text))
            {
                MessageBox.Show("Lütfen maç skorunu giriniz (Örn: 5-4).", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. SKOR FORMATI KONTROLÜ VE AYRIŞTIRMA (Bahis sistemi için gerekli)
            // Kullanıcı "5-4" girdiğinde bunu 5 ve 4 olarak ayırmalıyız.
            int evSahibiSkor = 0;
            int deplasmanSkor = 0;
            string[] skorParcalari = txtSkor.Text.Trim().Split('-');

            if (skorParcalari.Length != 2)
            {
                MessageBox.Show("Lütfen skoru araya tire koyarak giriniz. (Örnek: 5-4)", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sayısal kontrol
            if (!int.TryParse(skorParcalari[0], out evSahibiSkor) || !int.TryParse(skorParcalari[1], out deplasmanSkor))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    // 3. ADIM: RANDEVULAR TABLOSUNA SKORU YAZ
                    string sorguSkor = "UPDATE Randevular SET MacSkoru = @p1 WHERE RandevuID = @p2";
                    SqlCommand komutSkor = new SqlCommand(sorguSkor, conn);
                    komutSkor.Parameters.AddWithValue("@p1", txtSkor.Text);
                    komutSkor.Parameters.AddWithValue("@p2", GelenRandevuID);
                    komutSkor.ExecuteNonQuery();

                    // 4. ADIM: KULLANICININ TOPLAM GOL SAYISINI ARTIR
                    if (numGol.Value > 0)
                    {
                        string sorguGol = "UPDATE Users SET GolSayisi = GolSayisi + @g1 WHERE UserId = @u1";
                        SqlCommand komutGol = new SqlCommand(sorguGol, conn);
                        komutGol.Parameters.AddWithValue("@g1", Convert.ToInt32(numGol.Value));
                        komutGol.Parameters.AddWithValue("@u1", GelenUserID);
                        komutGol.ExecuteNonQuery();
                    }
                }

                // 5. ADIM: BAHİSLERİ DAĞIT (EN ÖNEMLİ KISIM) 💸
                // Skor başarıyla kaydedildiyse artık kazananlara parasını verebiliriz.
                try
                {
                    BahisIslemleri bahisMotoru = new BahisIslemleri();
                    // Ayrıştırdığımız skorları buraya gönderiyoruz
                    bahisMotoru.BahisleriDagit(GelenRandevuID, evSahibiSkor, deplasmanSkor);
                }
                catch (Exception exBahis)
                {
                    // Skor kaydedildi ama bahis dağıtılamadıysa kullanıcıyı uyar
                    MessageBox.Show("Skor kaydedildi fakat bahisler dağıtılırken bir hata oluştu: " + exBahis.Message, "Kritik Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Fonksiyondan çık, başarılı mesajı verme
                }

                // 6. BAŞARI MESAJI VE KAPANIŞ
                MessageBox.Show("Maç skoru kaydedildi ve bahis kazançları dağıtıldı!\nTeşekkürler.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}