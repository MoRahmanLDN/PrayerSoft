using System;

namespace PrayerSoft.Data
{
    public interface IConfiguration
    {
        void Load();
        string GetCalendarPath();
        TimeSpan GetImagesInterval();
        string GetImagesPath();
        string GetImagesPattern();
        TimeSpan GetMessagesInterval();
        string GetMessagesPath();
        string GetVideosPath();
        string GetVideosPattern();
    }
}