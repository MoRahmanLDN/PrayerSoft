using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockPrayerTimesRepository : IPrayerTimesRepository
    {
        public DailyPrayerTimes PrayerTimes { get; internal set; }

        public DailyPrayerTimes Get(DateTime date)
        {
            return PrayerTimes;    
        }
    }
}