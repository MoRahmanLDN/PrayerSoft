using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class WeeklyScheduleViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly ICalendar calendar;
        private DateTime lastRefresh;
        private Format format;

        public List<PrayersPerDayViewModel> WeeklyPrayers { get; set; }

        public WeeklyScheduleViewModel(IClock clock, ICalendar calendar)
        {
            this.clock = clock;
            this.calendar = calendar;
            format = new Format();
            WeeklyPrayers = new List<PrayersPerDayViewModel>();
        }

        public void Refresh()
        {
            var now = clock.Read();

            if (now.DayOfWeek != lastRefresh.DayOfWeek)
            {
                Reload(now);
            }
        }

        private void Reload(DateTime startDate)
        {
            WeeklyPrayers.Clear();

            for (int daysToAdd = 0; daysToAdd < 7; daysToAdd++)
            {
                var day = startDate.AddDays(daysToAdd);
                var prayers = calendar.GetPrayers(day).Select(Map).ToList();

                WeeklyPrayers.Add(new PrayersPerDayViewModel
                {
                    DayOfWeek = day.DayOfWeek.ToString(),
                    Prayers = prayers
                });
            }
        }

        private PrayerViewModel Map(Prayer prayer)
        {
            return new PrayerViewModel
            {
                Begins = format.ShortTime(prayer.Begins),
                Jamaat = format.ShortTime(prayer.Jamaat)
            };
        }
    }
}