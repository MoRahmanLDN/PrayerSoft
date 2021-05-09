namespace PrayerSoft.UI.DesignTime
{
    class DailyScheduleDesignTimeViewModel
    {
        public PrayerViewModel Fajr { get; set; } = new PrayerViewModel
        {
            PrayerName = "Fajr",
            Begins = "10:10",
            Jamaat = "11:11"
        };

        public PrayerViewModel Zuhr { get; set; } = new PrayerViewModel
        {
            PrayerName = "Zuhr",
            Begins = "12:12",
            Jamaat = "13:13"
        };

        public PrayerViewModel Asr { get; set; } = new PrayerViewModel
        {
            PrayerName = "Asr",
            Begins = "14:14",
            Jamaat = "15:15"
        };

        public PrayerViewModel Maghrib { get; set; } = new PrayerViewModel
        {
            PrayerName = "Maghrib",
            Begins = "16:16",
            Jamaat = "17:17"
        };

        public PrayerViewModel Isha { get; set; } = new PrayerViewModel
        {
            PrayerName = "Isha",
            Begins = "18:18",
            Jamaat = "19:19"
        };

        public string Sunrise { get; set; } = "01:01";
        public string Sunset { get; set; } = "02:02";
        public string SubSadiq { get; set; } = "03:03";
        public string Zawaal { get; set; } = "04:04";
    }
}
