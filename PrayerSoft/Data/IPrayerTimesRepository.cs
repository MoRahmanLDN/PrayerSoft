using System;

namespace PrayerSoft.Data
{
    public interface IPrayerTimesRepository
    {
        DailyPrayerTimes Get(DateTime date);
    }
}