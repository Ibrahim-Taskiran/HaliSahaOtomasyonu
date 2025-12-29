using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HaliSahaOtomasyon
{
    public partial class FrmProfil : DevExpress.XtraEditors.XtraForm
    {
        public FrmProfil()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        // 0 ise: Kendi profilim (Anasayfadan)
        // Değilse: Arkadaşın profili
        public int GelenKullaniciID = 0;
        string secilenDosyaYolu = "";

        // 1. FORM YÜKLENİRKEN
        private void FrmProfil_Load(object sender, EventArgs e)
        {
            if (UserSession.UserId <= 0)
            {
                XtraMessageBox.Show("Oturum hatası. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            int hedefId = (GelenKullaniciID == 0) ? UserSession.UserId : GelenKullaniciID;

            // Verileri Çek
            VerileriGetir(hedefId);

            // --- MİSAFİR MODU & PUANLAMA AYARLARI ---
            if (hedefId != UserSession.UserId)
            {
                // --- BAŞKASININ PROFİLİ ---
                this.Text = "Arkadaş Profili Görüntüle";

                // Başkasının bakiyesini göremezsin
                if (lblBakiye != null) lblBakiye.Visible = false;

                // Düzenleme butonlarını gizle
                btnKaydet.Visible = false;
                btnDuzenle.Visible = false;
                btnResimSec.Visible = false;

                // Puanlama Panelini GÖSTER
                if (grpPuanVer != null)
                {
                    grpPuanVer.Visible = true;
                    // Günlük Puan Kontrolü Yap
                    GunlukPuanKontrolu(hedefId);
                }

                KilidiDegistir(true);
            }
            else
            {
                // --- KENDİ PROFİLİM ---
                this.Text = "Profilim";

                // Bakiyeyi Getir (Sadece kendi profilimde)
                BakiyeGetir();

                // Puanlama Panelini GİZLE
                if (grpPuanVer != null) grpPuanVer.Visible = false;

                btnKaydet.Visible = true;
                btnDuzenle.Visible = true;
                btnResimSec.Visible = true;
                btnKaydet.Enabled = false;
                btnResimSec.Enabled = false;
                btnDuzenle.Enabled = true;

                KilidiDegistir(true);
            }
        }

        // --- YENİ EKLENEN: BAKİYE GETİR METODU ---
        void BakiyeGetir()
        {
            try
            {
                // Eğer lblBakiye tasarımda eklenmediyse hata vermesin diye kontrol
                if (lblBakiye == null) return;

                lblBakiye.Visible = true; // Kendi profilim olduğu için göster

                using (SqlConnection conn = bgl.Baglanti())
                {
                    // Veritabanından sadece Bakiye'yi çekiyoruz
                    SqlCommand cmd = new SqlCommand("SELECT Bakiye FROM Users WHERE UserId=@p1", conn);
                    cmd.Parameters.AddWithValue("@p1", UserSession.UserId);

                    object sonuc = cmd.ExecuteScalar();

                    if (sonuc != null && sonuc != DBNull.Value)
                    {
                        decimal para = Convert.ToDecimal(sonuc);
                        // "C2" formatı otomatik olarak TL simgesi ekler (Örn: 100.00 ₺)
                        lblBakiye.Text = "Mevcut Bakiye: " + para.ToString("C2");
                    }
                    else
                    {
                        lblBakiye.Text = "Mevcut Bakiye: 0.00 ₺";
                    }
                }
            }
            catch (Exception ex)
            {
                if (lblBakiye != null) lblBakiye.Text = "Bakiye yüklenemedi";
            }
        }

        // --- GÜNLÜK PUAN KONTROLÜ ---
        void GunlukPuanKontrolu(int arkadasId)
        {
            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    // Arkadaşlık kaydını bul
                    string sorgu = @"
                        SELECT ID, KimdenID, KimdenSonPuanTarih, KimeSonPuanTarih 
                        FROM Arkadaslar 
                        WHERE (KimdenID=@ben AND KimeID=@arkadas) OR (KimdenID=@arkadas AND KimeID=@ben)";

                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@ben", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@arkadas", arkadasId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int kimdenID = Convert.ToInt32(dr["KimdenID"]);
                        bool benBaslatanim = (kimdenID == UserSession.UserId);

                        object tarihObj = benBaslatanim ? dr["KimdenSonPuanTarih"] : dr["KimeSonPuanTarih"];

                        if (tarihObj != DBNull.Value)
                        {
                            DateTime sonTarih = Convert.ToDateTime(tarihObj);
                            if (sonTarih.Date == DateTime.Now.Date)
                            {
                                // Bugün puan vermiş
                                if (btnPuanKaydet != null)
                                {
                                    btnPuanKaydet.Enabled = false;
                                    btnPuanKaydet.Text = "Bugün Puan Verdiniz";
                                }
                                if (ratingPuanVer != null) ratingPuanVer.Enabled = false;
                            }
                        }
                    }
                    dr.Close();
                }
            }
            catch { }
        }

        // --- PUAN KAYDET BUTONU ---
        private void btnPuanKaydet_Click(object sender, EventArgs e)
        {
            if (ratingPuanVer.Rating == 0)
            {
                MessageBox.Show("Lütfen en az 1 yıldız veriniz.");
                return;
            }

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    // 1. Önce Arkadaşlık ID'sini bul
                    string bulSorgu = "SELECT ID, KimdenID FROM Arkadaslar WHERE (KimdenID=@ben AND KimeID=@arkadas) OR (KimdenID=@arkadas AND KimeID=@ben)";
                    SqlCommand cmdBul = new SqlCommand(bulSorgu, conn);
                    cmdBul.Parameters.AddWithValue("@ben", UserSession.UserId);
                    cmdBul.Parameters.AddWithValue("@arkadas", GelenKullaniciID);

                    SqlDataReader dr = cmdBul.ExecuteReader();
                    int kayitId = 0;
                    int kimdenId = 0;

                    if (dr.Read())
                    {
                        kayitId = Convert.ToInt32(dr["ID"]);
                        kimdenId = Convert.ToInt32(dr["KimdenID"]);
                    }
                    dr.Close();

                    if (kayitId == 0) return; // Arkadaşlık bulunamadı

                    // 2. Kullanıcıya Puan Ekle
                    string puanSql = "UPDATE Users SET ToplamPuan = ToplamPuan + @p, OySayisi = OySayisi + 1 WHERE UserId = @uid";
                    SqlCommand cmdPuan = new SqlCommand(puanSql, conn);
                    cmdPuan.Parameters.AddWithValue("@p", Convert.ToInt32(ratingPuanVer.Rating));
                    cmdPuan.Parameters.AddWithValue("@uid", GelenKullaniciID);
                    cmdPuan.ExecuteNonQuery();

                    // 3. Tarihi Güncelle (Damga Vur)
                    bool benBaslatanim = (kimdenId == UserSession.UserId);
                    string tarihSql = benBaslatanim ? "UPDATE Arkadaslar SET KimdenSonPuanTarih = GETDATE() WHERE ID=@id"
                                                    : "UPDATE Arkadaslar SET KimeSonPuanTarih = GETDATE() WHERE ID=@id";

                    SqlCommand cmdTarih = new SqlCommand(tarihSql, conn);
                    cmdTarih.Parameters.AddWithValue("@id", kayitId);
                    cmdTarih.ExecuteNonQuery();
                }

                MessageBox.Show("Puanınız başarıyla kaydedildi!");

                // Butonları kilitle
                btnPuanKaydet.Enabled = false;
                btnPuanKaydet.Text = "Bugün Puan Verdiniz";
                ratingPuanVer.Enabled = false;

                // Ekrandaki ortalamayı anlık güncellemek için verileri tekrar çek
                VerileriGetir(GelenKullaniciID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // --- VERİLERİ GETİR ---
        void VerileriGetir(int id)
        {
            try
            {
                if (bgl.Baglanti().State == ConnectionState.Open) bgl.Baglanti().Close();

                SqlCommand komut = new SqlCommand("Select * From Users Where UserId=@p1", bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", id);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    txtAd.Text = dr["FullName"].ToString();
                    txtMail.Text = dr["Email"].ToString();

                    if (dr["PhoneNumber"] != DBNull.Value) txtTelefon.Text = dr["PhoneNumber"].ToString();
                    if (dr["Sehir"] != DBNull.Value) cmbSehir.Text = dr["Sehir"].ToString();
                    if (dr["Mevki"] != DBNull.Value) cmbMevki.Text = dr["Mevki"].ToString();

                    try
                    {
                        spinMac.Value = dr["MacSayisi"] != DBNull.Value ? Convert.ToDecimal(dr["MacSayisi"]) : 0;
                        spinGol.Value = dr["GolSayisi"] != DBNull.Value ? Convert.ToDecimal(dr["GolSayisi"]) : 0;
                    }
                    catch { }

                    // Puan Hesaplama
                    int toplamPuan = dr["ToplamPuan"] != DBNull.Value ? Convert.ToInt32(dr["ToplamPuan"]) : 0;
                    int oySayisi = dr["OySayisi"] != DBNull.Value ? Convert.ToInt32(dr["OySayisi"]) : 0;

                    if (oySayisi > 0)
                    {
                        double ortalama = (double)toplamPuan / oySayisi;
                        ratingControl1.Rating = (decimal)ortalama;
                    }
                    else ratingControl1.Rating = 0;

                    // Resim
                    if (dr["ProfilResmiYolu"] != DBNull.Value)
                    {
                        string resimAdi = dr["ProfilResmiYolu"].ToString();
                        string tamYol = Path.Combine(Application.StartupPath, "Resimler", resimAdi);
                        if (File.Exists(tamYol))
                        {
                            using (var stream = new FileStream(tamYol, FileMode.Open, FileAccess.Read))
                            {
                                pictureEdit1.Image = Image.FromStream(stream);
                            }
                        }
                        else pictureEdit1.Image = null;
                    }
                    else pictureEdit1.Image = null;
                }
                dr.Close();
                bgl.Baglanti().Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Veri hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MEVCUT BUTONLAR (KAYDET, RESİM, DÜZENLE) ---
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (GelenKullaniciID != 0 && GelenKullaniciID != UserSession.UserId) return;

            try
            {
                string kaydedilecekDosyaAdi = "";
                if (!string.IsNullOrEmpty(secilenDosyaYolu))
                {
                    string hedefKlasor = Path.Combine(Application.StartupPath, "Resimler");
                    if (!Directory.Exists(hedefKlasor)) Directory.CreateDirectory(hedefKlasor);
                    string uzanti = Path.GetExtension(secilenDosyaYolu);
                    kaydedilecekDosyaAdi = UserSession.UserId + "_" + Guid.NewGuid().ToString().Substring(0, 5) + uzanti;
                    File.Copy(secilenDosyaYolu, Path.Combine(hedefKlasor, kaydedilecekDosyaAdi));
                }

                string sorgu = "";
                if (!string.IsNullOrEmpty(kaydedilecekDosyaAdi))
                    sorgu = "Update Users Set FullName=@p1, Sehir=@p2, Mevki=@p3, PhoneNumber=@p4, Email=@p5, MacSayisi=@p8, GolSayisi=@p9, ProfilResmiYolu=@p6 Where UserId=@p7";
                else
                    sorgu = "Update Users Set FullName=@p1, Sehir=@p2, Mevki=@p3, PhoneNumber=@p4, Email=@p5, MacSayisi=@p8, GolSayisi=@p9 Where UserId=@p7";

                SqlCommand komut = new SqlCommand(sorgu, bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", cmbSehir.Text);
                komut.Parameters.AddWithValue("@p3", cmbMevki.Text);
                komut.Parameters.AddWithValue("@p4", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p5", txtMail.Text);
                komut.Parameters.AddWithValue("@p8", Convert.ToInt32(spinMac.Value));
                komut.Parameters.AddWithValue("@p9", Convert.ToInt32(spinGol.Value));
                komut.Parameters.AddWithValue("@p7", UserSession.UserId);

                if (!string.IsNullOrEmpty(kaydedilecekDosyaAdi)) komut.Parameters.AddWithValue("@p6", kaydedilecekDosyaAdi);

                komut.ExecuteNonQuery();
                bgl.Baglanti().Close();

                UserSession.AdSoyad = txtAd.Text;
                UserSession.Sehir = cmbSehir.Text;
                UserSession.Mevki = cmbMevki.Text;

                secilenDosyaYolu = "";
                KilidiDegistir(true);
                ArkaPlanRengiDegistir(Color.White);
                btnKaydet.Enabled = false;
                btnDuzenle.Enabled = true;
                btnResimSec.Enabled = false;

                XtraMessageBox.Show("Profil başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları |*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image = Image.FromFile(ofd.FileName);
                secilenDosyaYolu = ofd.FileName;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            KilidiDegistir(false);
            ArkaPlanRengiDegistir(Color.LightYellow);
            btnKaydet.Enabled = true;
            btnDuzenle.Enabled = false;
            btnResimSec.Enabled = true;
        }

        void KilidiDegistir(bool kilitliMi)
        {
            txtAd.ReadOnly = kilitliMi;
            cmbMevki.ReadOnly = kilitliMi;
            cmbSehir.ReadOnly = kilitliMi;
            txtTelefon.ReadOnly = kilitliMi;
            txtMail.ReadOnly = kilitliMi;
            spinMac.Properties.ReadOnly = kilitliMi;
            spinGol.Properties.ReadOnly = kilitliMi;
            ratingControl1.ReadOnly = true;
        }

        void ArkaPlanRengiDegistir(Color renk)
        {
            txtAd.BackColor = renk; cmbMevki.BackColor = renk; cmbSehir.BackColor = renk; txtTelefon.BackColor = renk; txtMail.BackColor = renk;
        }
    }
}