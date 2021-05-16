using System;

namespace PrayerSoft.Utilities
{
    public class Date
    {
        public static string Hash(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static DateTime Combine(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }
}
