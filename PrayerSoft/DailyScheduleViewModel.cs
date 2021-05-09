using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class DailyScheduleViewModel: IViewModel
    {
        private IClock clock;
        private ICalendar calendar;
        private Format format;

        public PrayerViewModel Fajr { get; set; }
        public PrayerViewModel Zuhr { get; set; }
        public PrayerViewModel Asr { get; set; }
        public PrayerViewModel Maghrib { get; set; }
        public PrayerViewModel Isha { get; set; }

        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string SubSadiq { get; set; }
        public string Zawaal { get; set; }

        public DailyScheduleViewModel(IClock clock, ICalendar calendar)
        {
            this.clock = clock;
            this.calendar = calendar;
            format = new Format();

            Fajr = new PrayerViewModel { PrayerName = "Fajr" };
            Zuhr = new PrayerViewModel { PrayerName = "Zuhr" };
            Asr = new PrayerViewModel { PrayerName = "Asr" };
            Maghrib = new PrayerViewModel { PrayerName = "Maghrib" };
            Isha = new PrayerViewModel { PrayerName = "Isha" };
        }

        public void Refresh()
        {
            DateTime today = clock.Read();
            DailySchedule schedule = calendar.Get(today);

            Fajr.Begins = format.ShortTime(schedule.FajrBegins);
            Fajr.Jamaat = format.ShortTime(schedule.FajrJamaat);

            Zuhr.Begins = format.ShortTime(schedule.ZuhrBegins);
            Zuhr.Jamaat = format.ShortTime(schedule.ZuhrJamaat);

            Asr.Begins = format.ShortTime(schedule.AsrBegins);
            Asr.Jamaat = format.ShortTime(schedule.AsrJamaat);

            Maghrib.Begins = format.ShortTime(schedule.MaghribBegins);
            Maghrib.Jamaat = format.ShortTime(schedule.MaghribJamaat);

            Isha.Begins = format.ShortTime(schedule.IshaBegins);
            Isha.Jamaat = format.ShortTime(schedule.IshaJamaat);

            Sunrise = format.ShortTime(schedule.Sunrise);
            Sunset = format.ShortTime(schedule.Sunset);
            SubSadiq = format.ShortTime(schedule.SubSadiq);
            Zawaal = format.ShortTime(schedule.Zawaal);
        }
    }
}