using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem şuan bakımdadır.";

        public static string CarAdded = "Araç eklendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarListed = "Araçlar listelendi";
        public static string CarPriceInvalid = "Araç günlük fiyatı için girdiğiniz değer 0 dan büyük olmalıdır.";

        public static string BrandNameInvalid = "Marka adı en az 3 karakter olmalıdır.";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Markalar listelendi";

        public static string ColorNameInvalid = "Renk adı en az 3 karakter olmalıdır.";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorListed = "Renkler listelendi";
    }
}
