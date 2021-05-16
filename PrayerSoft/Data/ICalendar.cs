using System;
using System.Collections.Generic;

namespace PrayerSoft.Data
{
    public interface ICalendar
    {
        void Load();
        List<Prayer> GetPrayers(DateTime date);
        TimesOfDay GetTimesOfDay(DateTime date);
    }
}