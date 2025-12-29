using System;
using System.Collections.Generic;

namespace HalisahaOtomasyonu // Kendi proje adını buraya yaz
{
    // Ana kök nesne
    public class WeatherForecastRoot
    {
        public List<WeatherList> list { get; set; }
    }

    // Her 3 saatlik dilimi temsil eden nesne
    public class WeatherList
    {
        public long dt { get; set; } // Zaman damgası
        public MainInfo main { get; set; } // Sıcaklık bilgileri
        public List<WeatherInfo> weather { get; set; } // İkon ve açıklama
        public string dt_txt { get; set; } // Okunabilir tarih (Örn: "2025-12-20 15:00:00")
    }

    public class MainInfo
    {
        public double temp { get; set; } // Sıcaklık
    }

    public class WeatherInfo
    {
        public string description { get; set; } // Örn: "parçalı bulutlu"
        public string icon { get; set; } // Örn: "10d"
    }
}