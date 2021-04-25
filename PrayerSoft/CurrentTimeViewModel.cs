﻿using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class CurrentTimeViewModel
    {
        readonly IClock clock;
        readonly Format format;

        public CurrentTimeViewModel(IClock clock)
        {
            this.clock = clock;
            format = new Format();
        }

        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentIslamicDate { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            CurrentTime = format.Time(now);
            CurrentDate = format.Date(now);
            CurrentIslamicDate = format.IslamicDate(now);
        }
    }
}
