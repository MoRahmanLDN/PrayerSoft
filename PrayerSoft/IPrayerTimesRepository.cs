using System;

namespace PrayerSoft.Tests
{
    public interface IPrayerTimesRepository
    {
        DailyPrayerTimes Get(DateTime date);
    }
}