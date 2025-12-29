using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HaliSahaOtomasyon
{
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        // 1. FORM YÜKLENİRKEN
        private void FrmKayit_Load(object sender, EventArgs e)
        {
            // Başlangıç Ayarları
            rdbOyuncu.Checked = true;

            pnlOyuncu.Visible = true;
            pnlSahaSahibi.Visible = false;

            pnlSahaSahibi.Location = pnlOyuncu.Location;
        }

        // 2. SEÇİM DEĞİŞTİĞİNDE
        private void rdbSahaSahibi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSahaSahibi.Checked)
            {
                pnlSahaSahibi.Visible = true;
                pnlOyuncu.Visible = false;
            }
            else
            {
                pnlSahaSahibi.Visible = false;
                pnlOyuncu.Visible = true;
            }
        }

        // 3. KAYDET BUTONU
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // --- ORTAK BOŞ ALAN KONTROLLERİ ---
            if (txtAdSoyad.Text == "" || txtEmail.Text == "" || txtSifre.Text == "" || cmbSehir.Text == "")
            {
                MessageBox.Show("Lütfen temel bilgileri (Ad, Email, Şifre, Şehir) eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    // --- SENARYO 1: OYUNCU KAYDI ---
                    if (rdbOyuncu.Checked)
                    {
                        if (cmbMevki.Text == "")
                        {
                            MessageBox.Show("Lütfen mevki seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string sorgu = "INSERT INTO Users (FullName, Email, Password, PhoneNumber, UserType, Sehir, Mevki) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                        SqlCommand komut = new SqlCommand(sorgu, conn);

                        komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                        komut.Parameters.AddWithValue("@p2", txtEmail.Text);
                        komut.Parameters.AddWithValue("@p3", txtSifre.Text);
                        komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
                        komut.Parameters.AddWithValue("@p5", 1); // 1: Oyuncu
                        komut.Parameters.AddWithValue("@p6", cmbSehir.Text);
                        komut.Parameters.AddWithValue("@p7", cmbMevki.Text);

                        komut.ExecuteNonQuery();
                    }
                    // --- SENARYO 2: SAHA SAHİBİ KAYDI ---
                    else
                    {
                        if (txtTesisAdi.Text == "" || txtFiyat.Text == "")
                        {
                            MessageBox.Show("Lütfen tesis adı ve fiyat bilgisini giriniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // ADIM 1: Kişiyi Users'a kaydet, ID al
                        string userSorgu = @"INSERT INTO Users (FullName, Email, Password, PhoneNumber, UserType, Sehir) 
                                             VALUES (@p1, @p2, @p3, @p4, @p5, @p6);
                                             SELECT SCOPE_IDENTITY();";

                        SqlCommand komutUser = new SqlCommand(userSorgu, conn);
                        komutUser.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                        komutUser.Parameters.AddWithValue("@p2", txtEmail.Text);
                        komutUser.Parameters.AddWithValue("@p3", txtSifre.Text);
                        komutUser.Parameters.AddWithValue("@p4", mskTelefon.Text);
                        komutUser.Parameters.AddWithValue("@p5", 2); // 2: Saha Sahibi
                        komutUser.Parameters.AddWithValue("@p6", cmbSehir.Text);

                        int yeniSahipID = Convert.ToInt32(komutUser.ExecuteScalar());

                        // ADIM 2: Sahalar tablosuna detayları kaydet (SahaTanimi ÇIKARILDI)
                        string sahaSorgu = @"INSERT INTO Sahalar (SahipID, TesisAdi, Fiyat, Enlem, Boylam, Il) 
                                             VALUES (@s1, @s2, @s3, @s4, @s5, @s6)";

                        SqlCommand komutSaha = new SqlCommand(sahaSorgu, conn);
                        komutSaha.Parameters.AddWithValue("@s1", yeniSahipID);
                        komutSaha.Parameters.AddWithValue("@s2", txtTesisAdi.Text);

                        // Fiyat Dönüşümü
                        decimal fiyat = 0;
                        decimal.TryParse(txtFiyat.Text, out fiyat);
                        komutSaha.Parameters.AddWithValue("@s3", fiyat);

                        komutSaha.Parameters.AddWithValue("@s4", txtEnlem.Text);
                        komutSaha.Parameters.AddWithValue("@s5", txtBoylam.Text);
                        komutSaha.Parameters.AddWithValue("@s6", cmbSehir.Text);

                        komutSaha.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kayıt Başarıyla Tamamlandı!", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}