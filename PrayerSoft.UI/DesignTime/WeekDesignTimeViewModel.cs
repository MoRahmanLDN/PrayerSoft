namespace PrayerSoft.UI.DesignTime
{
    class WeekDesignTimeViewModel
    {
        public MosqueDesignTimeViewModel Mosque { get; set; } = new MosqueDesignTimeViewModel();
        public WeeklyScheduleDesignTimeViewModel Schedule { get; set; } = new WeeklyScheduleDesignTimeViewModel();
        public MessagesDesignTimeViewModel Messages { get; set; } = new MessagesDesignTimeViewModel();
    }
}
