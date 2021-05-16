using PrayerSoft.Data;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests.Mocks
{
    public class MockCalendar: ICalendar
    {
        public List<Prayer> Prayers { get; set; }
        public TimesOfDay TimesOfDay { get; set; }

        public List<Prayer> GetPrayers(DateTime date)
        {
            return Prayers;
        }

        public TimesOfDay GetTimesOfDay(DateTime date)
        {
            return TimesOfDay;    
        }

        public void Load()
        {
        }
    }
}