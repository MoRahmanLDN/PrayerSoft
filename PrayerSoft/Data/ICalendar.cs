using System;

namespace PrayerSoft.Data
{
    public interface ICalendar
    {
        DailySchedule Get(DateTime date);
    }
}