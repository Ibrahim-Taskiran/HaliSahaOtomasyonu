using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSahaOtomasyon
{
    // 'static' olması, bu sınıftan nesne üretmeden (new demeden)
    // her yerden UserSession.UserId diyerek ulaşabilmemizi sağlar.
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string AdSoyad { get; set; }

        public static string Sehir { get; set; }
        public static string Mevki { get; set; }
    }
}