using System;
using System.Data;
using System.Data.SqlClient;

namespace HaliSahaOtomasyon
{
    public class BahisIslemleri
    {
        SqlBaglantisi bgl = new SqlBaglantisi();

        // Oranları tutacak basit bir yapı
        public class MacOranlari
        {
            public double OranEvSahibi { get; set; }
            public double OranDeplasman { get; set; }
            public double EvSahibiGuc { get; set; }
            public double DeplasmanGuc { get; set; }
            public bool BahisAcilabilirMi { get; set; } // Kadrolar dolu mu?
        }

        public MacOranlari OranHesapla(int randevuId)
        {
            MacOranlari sonuc = new MacOranlari();
            sonuc.BahisAcilabilirMi = false;

            double evSahibiToplamPuan = 0;
            int evSahibiOyuncuSayisi = 0;

            double deplasmanToplamPuan = 0;
            int deplasmanOyuncuSayisi = 0;

            // 1. Veritabanından Oyuncuların Puanlarını Çek
            // TakimTuru -> 0: Ev Sahibi, 1: Deplasman
            string sorgu = @"
                SELECT 
                    mk.TakimTuru,
                    ISNULL(CAST(u.ToplamPuan AS FLOAT) / NULLIF(u.OySayisi, 0), 1.0) as OyuncuPuani
                FROM MacKadrosu mk
                JOIN Users u ON mk.OyuncuID = u.UserId
                WHERE mk.RandevuID = @p1";

            try
            {
                using (SqlConnection conn = bgl.Baglanti())
                {
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", randevuId);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int takim = Convert.ToInt32(dr["TakimTuru"]);
                        double puan = Convert.ToDouble(dr["OyuncuPuani"]);

                        // Puanı 0 olan (yeni üye) varsa varsayılan 1.0 kabul edelim ki oran bozulmasın
                        if (puan == 0) puan = 1.0;

                        if (takim == 0) // Ev Sahibi
                        {
                            evSahibiToplamPuan += puan;
                            evSahibiOyuncuSayisi++;
                        }
                        else // Deplasman
                        {
                            deplasmanToplamPuan += puan;
                            deplasmanOyuncuSayisi++;
                        }
                    }
                    dr.Close();
                }

                // 2. Kontrol: Her iki takımda da oyuncu var mı?
                // (Boş takıma bahis oynanamaz)
                if (evSahibiOyuncuSayisi > 0 && deplasmanOyuncuSayisi > 0)
                {
                    sonuc.BahisAcilabilirMi = true;

                    // 3. Takım Güç Ortalamalarını Bul (Senin istediğin mantık)
                    sonuc.EvSahibiGuc = Math.Round(evSahibiToplamPuan / evSahibiOyuncuSayisi, 2);
                    sonuc.DeplasmanGuc = Math.Round(deplasmanToplamPuan / deplasmanOyuncuSayisi, 2);

                    // 4. Oran Hesaplama (Ters Orantı)
                    // Güçlerin toplamını buluyoruz.
                    double toplamGuc = sonuc.EvSahibiGuc + sonuc.DeplasmanGuc;

                    // Olasılıkları hesaplıyoruz (Güçlü olanın kazanma ihtimali yüksek)
                    double olasilikEv = sonuc.EvSahibiGuc / toplamGuc;
                    double olasilikDep = sonuc.DeplasmanGuc / toplamGuc;

                    // Bahis Oranı = 1 / Olasılık
                    // Örn: Ev Sahibi %66 ihtimalse -> Oran 1.50
                    // Örn: Deplasman %33 ihtimalse -> Oran 3.00
                    sonuc.OranEvSahibi = Math.Round(1 / olasilikEv, 2);
                    sonuc.OranDeplasman = Math.Round(1 / olasilikDep, 2);

                    // 5. Güvenlik Önlemi: Oran asla 1.00 veya altı olmasın (Yoksa kazanç olmaz)
                    if (sonuc.OranEvSahibi <= 1.05) sonuc.OranEvSahibi = 1.05;
                    if (sonuc.OranDeplasman <= 1.05) sonuc.OranDeplasman = 1.05;
                }
            }
            catch
            {
                sonuc.BahisAcilabilirMi = false;
            }

            return sonuc;
        }
        // --- BU METODU BahisIslemleri.cs İÇİNE EKLE ---

        public void BahisleriDagit(int randevuId, int skorEv, int skorDep)
        {
            // 1. Maçın Kazananını Belirle
            int kazananTakim = -1; // -1: Berabere, 0: Ev, 1: Deplasman

            if (skorEv > skorDep) kazananTakim = 0;
            else if (skorDep > skorEv) kazananTakim = 1;

            // Not: Beraberlik durumunda kimse kazanmaz (İddaa mantığı), para kasa da kalır.
            // İstersen beraberlikte iade mantığı da ekleyebiliriz ama şimdilik standart yapalım.

            using (SqlConnection conn = bgl.Baglanti())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Transaction başlatıyoruz (Para işlemleri şakaya gelmez)
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 2. Bu maça oynanan ve henüz sonuçlanmamış (Durum=0) tüm bahisleri çek
                    string sorgu = "SELECT BahisID, UserID, SecilenTakim, OynananOran, YatirilanTutar FROM Bahisler WHERE RandevuID=@p1 AND Durum=0";
                    SqlCommand cmdGetir = new SqlCommand(sorgu, conn, trans);
                    cmdGetir.Parameters.AddWithValue("@p1", randevuId);

                    SqlDataAdapter da = new SqlDataAdapter(cmdGetir);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        int bahisId = Convert.ToInt32(dr["BahisID"]);
                        int userId = Convert.ToInt32(dr["UserID"]);
                        int secilen = Convert.ToInt32(dr["SecilenTakim"]);
                        decimal oran = Convert.ToDecimal(dr["OynananOran"]);
                        decimal tutar = Convert.ToDecimal(dr["YatirilanTutar"]);

                        if (kazananTakim != -1 && secilen == kazananTakim)
                        {
                            // --- KAZANDI! ---
                            decimal kazanilanTutar = tutar * oran;

                            // A) Bahis durumunu '1' (Kazandı) yap
                            SqlCommand cmdGuncelle = new SqlCommand("UPDATE Bahisler SET Durum=1 WHERE BahisID=@bId", conn, trans);
                            cmdGuncelle.Parameters.AddWithValue("@bId", bahisId);
                            cmdGuncelle.ExecuteNonQuery();

                            // B) Kullanıcının cüzdanına parayı yatır
                            SqlCommand cmdParaYatir = new SqlCommand("UPDATE Users SET Bakiye = Bakiye + @para WHERE UserId=@uId", conn, trans);
                            cmdParaYatir.Parameters.AddWithValue("@para", kazanilanTutar);
                            cmdParaYatir.Parameters.AddWithValue("@uId", userId);
                            cmdParaYatir.ExecuteNonQuery();
                        }
                        else
                        {
                            // --- KAYBETTİ ---
                            // Bahis durumunu '2' (Kaybetti) yap
                            SqlCommand cmdKaybetti = new SqlCommand("UPDATE Bahisler SET Durum=2 WHERE BahisID=@bId", conn, trans);
                            cmdKaybetti.Parameters.AddWithValue("@bId", bahisId);
                            cmdKaybetti.ExecuteNonQuery();
                        }
                    }

                    trans.Commit(); // Her şey yolundaysa kaydet
                }
                catch (Exception)
                {
                    trans.Rollback(); // Hata varsa her şeyi geri al
                    throw; // Hatayı fırlat ki form tarafında görelim
                }
            }
        }
    }
}