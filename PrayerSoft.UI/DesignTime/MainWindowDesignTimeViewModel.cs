namespace PrayerSoft.UI.DesignTime
{
    class MainWindowDesignTimeViewModel
    {
        public CurrentTimeDesignTimeViewModel Today { get; set; } = new CurrentTimeDesignTimeViewModel();
        public PrayerTimesTodayDesignTimeViewModel PrayersToday { get; set; } = new PrayerTimesTodayDesignTimeViewModel();
    }
}
