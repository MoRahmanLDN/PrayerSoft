using System;

namespace PrayerSoft
{
    public class DailyPrayerTimes
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
    }
}