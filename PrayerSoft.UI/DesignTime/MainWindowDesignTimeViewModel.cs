﻿namespace PrayerSoft.UI.DesignTime
{
    class MainWindowDesignTimeViewModel
    {
        public DateAndTimeDesignTimeViewModel DateAndTime { get; set; } = new DateAndTimeDesignTimeViewModel();
        public DailyScheduleDesignTimeViewModel DailySchedule { get; set; } = new DailyScheduleDesignTimeViewModel();
    }
}
