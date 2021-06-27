using System;

namespace PrayerSoft.Data
{
    public interface IConfiguration
    {
        void Load();
        string GetRamadanPath();
        string GetCalendarPath();
        TimeSpan GetImagesInterval();
        string GetImagesPath();
        string GetImagesPattern();
        TimeSpan GetMessagesInterval();
        string GetMessagesPath();
        string GetVideosPath();
        string GetVideosPattern();
        TimeSpan GetPrayerJamaatInterval();
        TimeSpan GetWeeklyTimetableInterval();
        TimeSpan GetTodayTimetableInterval();
        DateTime GetEidUlFitr();
        DateTime GetEidUlAdha();
    }
}