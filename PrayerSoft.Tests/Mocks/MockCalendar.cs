using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockCalendar: ICalendar
    {
        public DailySchedule DailySchedule { get; internal set; }

        public DailySchedule Get(DateTime date)
        {
            return DailySchedule;    
        }

        public void Load()
        {
        }
    }
}