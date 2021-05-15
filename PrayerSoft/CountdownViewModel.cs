using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class CountdownViewModel: IViewModel
    {
        private readonly IClock clock;
        private readonly ICalendar calendar;
        private readonly Format format;

        public bool IsVisible { get; set; }

        public CountdownViewModel(IClock clock, ICalendar calendar)
        {
            this.calendar = calendar;
            this.clock = clock;
            this.format = new Format();
        }

        public string Remaining { get; set; }

        public void Refresh()
        {
            DateTime now = clock.Read();
            DailySchedule schedule = calendar.Get(now);

            var next = schedule.JamaatTimes.Where(t => t > now);
            IsVisible = next.Any();

            if (IsVisible)
            {
                var remaining = next.Min(t => t - now);
                Remaining = format.LongTime(remaining);
            }
        }
    }
}