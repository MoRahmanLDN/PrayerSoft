using System;

namespace PrayerSoft
{
    public class Clock : IClock
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
