using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class CountdownViewModel: IViewModel
    {
        private readonly IClock clock;
        private readonly ICalendar calendar;
        private readonly Format format;

        public CountdownViewModel(IClock clock, ICalendar calendar)
        {
            this.calendar = calendar;
            this.clock = clock;
            this.format = new Format();
        }

        public string Remaining { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            var schedule = calendar.Get(now);

            var times = new List<DateTime> 
            {
                schedule.FajrJamaat,
                schedule.ZuhrJamaat,
                schedule.AsrJamaat, 
                schedule.MaghribJamaat, 
                schedule.IshaJamaat 
            };

            var remaining = times.Where(t => t > now).Min(t => t - now);

            Remaining = format.LongTime(remaining);
        }
    }
}