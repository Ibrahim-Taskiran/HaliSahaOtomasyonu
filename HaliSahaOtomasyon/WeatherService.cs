using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace HalisahaOtomasyonu
{
    public class WeatherService
    {
        // API Key'in burada tanımlı
        private const string API_KEY = "3705be414d9346c2f1c9fdb07443cc07";

        // DİKKAT: Artık sabit LAT/LON yok. Metot çağrılırken dışarıdan gönderilecek.

        // Metot artık enlem (lat) ve boylam (lon) parametrelerini istiyor
        public async Task<WeatherForecastRoot> GetHavaDurumuTahmini(string lat, string lon)
        {
            // Eğer koordinat gelmezse (veya boşsa) işlem yapma, null dön.
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                return null;
            }

            // URL Oluşturma: Dışarıdan gelen lat ve lon değerlerini buraya koyuyoruz.
            string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&lang=tr&appid={API_KEY}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // İsteği gönder
                    var response = await client.GetStringAsync(url);

                    // JSON'ı C# nesnesine çevir
                    var data = JsonConvert.DeserializeObject<WeatherForecastRoot>(response);
                    return data;
                }
                catch (Exception ex)
                {
                    // Hata olursa (internet yoksa, api key yanlışsa vs.)
                    System.Diagnostics.Debug.WriteLine("Hava durumu hatası: " + ex.Message);
                    // İstersen hatayı görmek için burayı açabilirsin:
                    // System.Windows.Forms.MessageBox.Show("Hava Hatası: " + ex.Message);
                    return null;
                }
            }
        }
    }
}