using System;

namespace PrayerSoft.Data
{
    public interface ICalendar
    {
        void Load();
        DailySchedule Get(DateTime date);
    }
}