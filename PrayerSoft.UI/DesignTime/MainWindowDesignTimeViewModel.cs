﻿namespace PrayerSoft.UI.DesignTime
{
    class MainWindowDesignTimeViewModel
    {
        public DateAndTimeDesignTimeViewModel DateAndTime { get; set; } = new DateAndTimeDesignTimeViewModel();
        public DailyScheduleDesignTimeViewModel DailySchedule { get; set; } = new DailyScheduleDesignTimeViewModel();
        public CountdownDesignTimeViewModel Countdown { get; set; } = new CountdownDesignTimeViewModel();
        public MessagesDesignTimeViewModel Messages { get; set; } = new MessagesDesignTimeViewModel();
        public RamadanDesignTimeViewModel Ramadan { get; set; } = new RamadanDesignTimeViewModel();
    }
}
