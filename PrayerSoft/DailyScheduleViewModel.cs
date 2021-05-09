using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class DailyScheduleViewModel: IViewModel
    {
        private IClock clock;
        private ICalendar calendar;
        private Format format;
        
        private PrayerViewModel fajr;
        private PrayerViewModel zuhr;
        private PrayerViewModel asr;
        private PrayerViewModel maghrib;
        private PrayerViewModel isha;

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

            fajr = new PrayerViewModel { PrayerName = "Fajr" };
            zuhr = new PrayerViewModel { PrayerName = "Zuhr" };
            asr = new PrayerViewModel { PrayerName = "Asr" };
            maghrib = new PrayerViewModel { PrayerName = "Maghrib" };
            isha = new PrayerViewModel { PrayerName = "Isha" };

            Prayers = new List<PrayerViewModel> { fajr, zuhr, asr, maghrib, isha };
        }

        public void Refresh()
        {
            DateTime now = clock.Read();
            DailySchedule schedule = calendar.Get(now);

            Format(schedule);
            MarkNextPrayer(now, schedule);
        }

        private void Format(DailySchedule schedule)
        {
            fajr.Begins = format.ShortTime(schedule.FajrBegins);
            fajr.Jamaat = format.ShortTime(schedule.FajrJamaat);

            zuhr.Begins = format.ShortTime(schedule.ZuhrBegins);
            zuhr.Jamaat = format.ShortTime(schedule.ZuhrJamaat);

            asr.Begins = format.ShortTime(schedule.AsrBegins);
            asr.Jamaat = format.ShortTime(schedule.AsrJamaat);

            maghrib.Begins = format.ShortTime(schedule.MaghribBegins);
            maghrib.Jamaat = format.ShortTime(schedule.MaghribJamaat);

            isha.Begins = format.ShortTime(schedule.IshaBegins);
            isha.Jamaat = format.ShortTime(schedule.IshaJamaat);

            Sunrise = format.ShortTime(schedule.Sunrise);
            Sunset = format.ShortTime(schedule.Sunset);
            SubSadiq = format.ShortTime(schedule.SubSadiq);
            Zawaal = format.ShortTime(schedule.Zawaal);
        }

        private void MarkNextPrayer(DateTime now, DailySchedule schedule)
        {
            Prayers.ForEach(p => p.IsNext = false);

            if (now < schedule.FajrJamaat)
            {
                fajr.IsNext = true;
                return;
            }
            if (now < schedule.ZuhrJamaat)
            {
                zuhr.IsNext = true;
                return;
            }
            if (now < schedule.AsrJamaat)
            {
                asr.IsNext = true;
                return;
            }
            if (now < schedule.MaghribJamaat)
            {
                maghrib.IsNext = true;
                return;
            }
            if (now < schedule.IshaJamaat)
            {
                isha.IsNext = true;
                return;
            }
        }
    }
}