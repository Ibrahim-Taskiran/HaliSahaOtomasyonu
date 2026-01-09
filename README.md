# Halı Saha Otomasyonu ⚽

Halı Saha Otomasyonu, halı saha maçlarını organize etmek, oyuncu kadroları oluşturmak, sahaları yönetmek ve maç istatistiklerini takip etmek için geliştirilmiş kapsamlı bir **Windows Form (C#)** uygulamasıdır. Kullanıcıların sosyalleşebileceği, maç, gol ve puan istatistiklerini görüntüleyebileceği interaktif bir platform sunar.

## 🚀 Özellikler

Bu proje, oyuncular ve saha yöneticileri için birçok gelişmiş modül içerir:

### 👤 Kullanıcı ve Profil Yönetimi
*   **Güvenli Giriş/Kayıt:** Kullanıcılar güvenli bir şekilde hesap oluşturabilir ve oturum açabilir.
*   **Profil İstatistikleri:** Oynanan maç sayısı, atılan goller, ve puan durumu gibi kişisel performans verileri grafiklerle sunulur.
*   **Sosyal Etkileşim:** Arkadaş ekleme, listeleme ve diğer oyuncuların profillerine yorum yapma özelliği.

### 🏟️ Saha ve Randevu Sistemi
*   **Saha Yönetimi:** Saha yöneticileri yeni saha ekleyebilir, sahanın özelliklerini (çim türü, boyut vb.) ve **konum bilgilerini (Enlem/Boylam)** sisteme kaydedebilir.
*   **Fotoğraf Yükleme:** Sahalara ait görseller sisteme yüklenebilir.
*   **Randevu Takvimi:** Kullanıcılar istedikleri saha için boş saatleri görüntüleyip randevu oluşturabilir.

### ⚽ Maç ve Kadro İşlemleri
*   **Kadro Oluşturucu:** Sürükle-bırak mantığı veya seçim menüleri ile interaktif kadro kurma ekranı.
*   **Maç Ekleme:** Geçmiş maçların skorlarını ve detaylarını sisteme girerek istatistikleri güncel tutma.
*   **Skor Girişi:** Oynanan müsabakaların sonuçları girildiğinde oyuncu puanları ve istatistikleri otomatik güncellenir.

### 🎲 Bahis ve Eğlence
*   **Sanal Bahis:** Kullanıcılar yaklaşan maçlar veya sistemdeki etkinlikler üzerine sanal puanlarla bahis oynayabilir.

### ☁️ Diğer Entegrasyonlar
*   **Hava Durumu:** Maç planlaması yaparken *OpenWeatherMap API* entegrasyonu sayesinde sahadaki hava durumu anlık olarak kontrol edilebilir.
*   **Modern Arayüz:** *DevExpress* bileşenleri ve kullanıcı dostu temalar (Koyu/Açık mod desteği) ile zenginleştirilmiş görsel deneyim.

---

## 🛠 Kullanılan Teknolojiler

*   **Dil:** C# (.NET Framework 4.8)
*   **Arayüz:** Windows Forms, DevExpress UI Controls
*   **Veritabanı:** Microsoft SQL Server (LocalDB - `SosyalHalisahaDB.mdf`)
*   **Veri Erişimi:** ADO.NET (SqlBaglantisi sınıfı üzerinden)
*   **API:** OpenWeatherMap API (Hava durumu verileri için)
*   **Kütüphaneler:**
    *   `Newtonsoft.Json`: JSON verilerini işlemek için.
    *   `OpenWeatherMapSharp`: Hava durumu servisi için.

---

## 💻 Kurulum ve Çalıştırma Rehberi

Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

1.  **Projeyi Klonlayın:**
    ```bash
    git clone https://github.com/Ibrahim-Taskiran/HaliSahaOtomasyon.git
    ```

2.  **Veritabanı Ayarları:**
    *   Proje, Visual Studio'nun `(localdb)\MSSQLLocalDB` sunucusunu ve proje dizinindeki `SosyalHalisahaDB.mdf` dosyasını kullanacak şekilde yapılandırılmıştır.
    *   Bilgisayarınızda SQL Server LocalDB yüklü ise (`VS Installer` ile "Data storage and processing" seçerek yükleyebilirsiniz), ek bir ayar yapmanıza gerek yoktur.
    *   Farklı bir SQL sunucusu kullanacaksanız, `SqlBaglantisi.cs` veya `App.config` içindeki `connectionString` değerini düzenleyin.

3.  **Visual Studio ile Açın:**
    *   `HaliSahaOtomasyon.sln` dosyasını çift tıklayarak çözümü açın.

4.  **NuGet Paketlerini Yükleyin:**
    *   "Solution Explorer" penceresinde Çözüme sağ tıklayın ve **"Restore NuGet Packages"** seçeneğini seçin. Bu işlem gerekli kütüphaneleri indirecektir.

5.  **Çalıştırın:**
    *   `F5` tuşuna basarak uygulamayı başlatın.

---

## 📂 Proje Yapısı

*   **FrmGiris / FrmKayitModul:** Yetkilendirme ekranları.
*   **FrmAnaModul:** Uygulamanın ana iskeleti ve menü yönetimi.
*   **FrmSahaEkle / FrmSahaPaneli:** Saha envanter ve ekleme işlemleri.
*   **FrmKadroOluştur:** Takım kurma arayüzü.
*   **SqlBaglantisi.cs:** Merkezi veritabanı bağlantı sınıfı.
*   **WeatherService.cs:** Hava durumu API servis katmanı.

---

## 🤝 Katkıda Bulunma

1.  Bu depoyu Fork'layın.
2.  Yeni bir Branch oluşturun (`git checkout -b feature/YeniOzellik`).
3.  Değişikliklerinizi Commit edin (`git commit -m 'Yeni özellik eklendi'`).
4.  Branch'inizi Push edin (`git push origin feature/YeniOzellik`).
5.  Bir Pull Request (PR) oluşturun.

---

## 📄 Lisans

Bu proje MIT Lisansı altında sunulmaktadır.
