using System.Collections.Generic;

namespace PrayerSoft.UI.DesignTime
{
    class DailyScheduleDesignTimeViewModel
    {
        public List<PrayerViewModel> Prayers { get; set; } = new List<PrayerViewModel>
        {
            new PrayerViewModel
            {
                PrayerName = "Fajr",
                Begins = "10:10",
                Jamaat = "11:11"
            },
            new PrayerViewModel
            {
                PrayerName = "Zuhr",
                Begins = "12:12",
                Jamaat = "13:13"
            },new PrayerViewModel
            {
                PrayerName = "Asr",
                Begins = "14:14",
                Jamaat = "15:15"
            },new PrayerViewModel
            {
                PrayerName = "Maghrib",
                Begins = "16:16",
                Jamaat = "17:17"
            },new PrayerViewModel
            {
                PrayerName = "Isha",
                Begins = "18:18",
                Jamaat = "19:19"
            }
        };

        public string Sunrise { get; set; } = "01:01";
        public string Sunset { get; set; } = "02:02";
        public string SubSadiq { get; set; } = "03:03";
        public string Zawaal { get; set; } = "04:04";
    }
}
