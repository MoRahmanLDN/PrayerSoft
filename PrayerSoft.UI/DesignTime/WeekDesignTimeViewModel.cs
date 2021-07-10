namespace PrayerSoft.UI.DesignTime
{
    class WeekDesignTimeViewModel
    {
        public WeeklyScheduleDesignTimeViewModel Schedule { get; set; } = new WeeklyScheduleDesignTimeViewModel();
        public MessagesDesignTimeViewModel Messages { get; set; } = new MessagesDesignTimeViewModel();
    }
}
