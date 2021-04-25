using System;

namespace PrayerSoft
{
    public class Clock : IClock
    {
        public DateTime Read()
        {
            return DateTime.Now;
        }
    }
}
