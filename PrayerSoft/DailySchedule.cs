using System;
using System.Collections.Generic;

namespace PrayerSoft
{
    public class DailySchedule
    {
        public DateTime FajrBegins { get; set; }
        public DateTime FajrJamaat { get; set; }

        public DateTime ZuhrBegins { get; set; }
        public DateTime ZuhrJamaat { get; set; }

        public DateTime AsrBegins { get; set; }
        public DateTime AsrJamaat { get; set; }

        public DateTime MaghribBegins { get; set; }
        public DateTime MaghribJamaat { get; set; }

        public DateTime IshaBegins { get; set; }
        public DateTime IshaJamaat { get; set; }

        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public DateTime SubSadiq { get; set; }
        public DateTime Zawaal { get; set; }

        public List<DateTime> JamaatTimes => new List<DateTime>
        {
            FajrJamaat,
            AsrJamaat,
            ZuhrJamaat,
            MaghribJamaat,
            IshaJamaat
        };
    }
}