using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class DailyScheduleViewModel: IViewModel
    {
        private IClock clock;
        private ICalendar calendar;
        private Format format;
        
        public List<PrayerViewModel> Prayers { get; set; }
        
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string SubSadiq { get; set; }
        public string Zawaal { get; set; }

        public DailyScheduleViewModel(IClock clock, ICalendar calendar)
        {
            this.clock = clock;
            this.calendar = calendar;
            format = new Format();
        }

        public void Refresh()
        {
            DateTime now = clock.Read();

            List<Prayer> prayers = calendar.GetPrayers(now);
            Format(prayers);

            TimesOfDay schedule = calendar.GetTimesOfDay(now);
            Format(schedule);

            MarkNextPrayer(now, prayers);
        }

        private void Format(List<Prayer> prayers)
        {
            Prayers = prayers.Select(prayer => new PrayerViewModel
            {
                PrayerName = prayer.Name,
                Begins = format.ShortTime(prayer.Begins),
                Jamaat = format.ShortTime(prayer.Jamaat),
            }).ToList();
        }

        private void Format(TimesOfDay timesOfDay)
        {
            Sunrise = format.ShortTime(timesOfDay.Sunrise);
            Sunset = format.ShortTime(timesOfDay.Sunset);
            SubSadiq = format.ShortTime(timesOfDay.SubSadiq);
            Zawaal = format.ShortTime(timesOfDay.Zawaal);
        }

        private void MarkNextPrayer(DateTime now, List<Prayer> prayers)
        {
            Prayers.ForEach(p => p.IsNext = false);

            for (int i = 0; i < prayers.Count; i++)
            {
                if (now < prayers[i].Jamaat)
                {
                    Prayers[i].IsNext = true;
                    return;
                }
            }
        }
    }
}