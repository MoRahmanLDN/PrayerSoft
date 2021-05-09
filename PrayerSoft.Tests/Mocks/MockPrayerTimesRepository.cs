using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockPrayerTimesRepository : ICalendar
    {
        public DailySchedule PrayerTimes { get; internal set; }

        public DailySchedule Get(DateTime date)
        {
            return PrayerTimes;    
        }
    }
}