using System;

namespace PrayerSoft
{
    public interface IPrayerTimesRepository
    {
        DailyPrayerTimes Get(DateTime date);
    }
}