using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockPrayerTimesRepository : IPrayerTimesRepository
    {
        public MockPrayerTimesRepository()
        {
        }

        public DailyPrayerTimes PrayerTimes { get; internal set; }

        public DailyPrayerTimes Get(DateTime date)
        {
            return PrayerTimes;    
        }
    }
}