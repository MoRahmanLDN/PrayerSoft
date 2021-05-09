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

        public DailyScheduleViewModel(IClock clock, ICalendar calendar)
        {
            this.clock = clock;
            this.calendar = calendar;
            format = new Format();
        }

        public string FajrBegins { get; set; }
        public string FajrJamaat { get; set; }

        public string ZuhrBegins { get; set; }
        public string ZuhrJamaat { get; set; }

        public string AsrBegins { get; set; }
        public string AsrJamaat { get; set; }

        public string MaghribBegins { get; set; }
        public string MaghribJamaat { get; set; }

        public string IshaBegins { get; set; }
        public string IshaJamaat { get; set; }

        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string SubSadiq { get; set; }
        public string Zawaal { get; set; }

        public void Refresh()
        {
            DateTime today = clock.Read();
            DailySchedule schedule = calendar.Get(today);

            FajrBegins = format.ShortTime(schedule.FajrBegins);
            FajrJamaat = format.ShortTime(schedule.FajrJamaat);

            ZuhrBegins = format.ShortTime(schedule.ZuhrBegins);
            ZuhrJamaat = format.ShortTime(schedule.ZuhrJamaat);

            AsrBegins = format.ShortTime(schedule.AsrBegins);
            AsrJamaat = format.ShortTime(schedule.AsrJamaat);

            MaghribBegins = format.ShortTime(schedule.MaghribBegins);
            MaghribJamaat = format.ShortTime(schedule.MaghribJamaat);

            IshaBegins = format.ShortTime(schedule.IshaBegins);
            IshaJamaat = format.ShortTime(schedule.IshaJamaat);

            Sunrise = format.ShortTime(schedule.Sunrise);
            Sunset = format.ShortTime(schedule.Sunset);
            SubSadiq = format.ShortTime(schedule.SubSadiq);
            Zawaal = format.ShortTime(schedule.Zawaal);
        }
    }
}