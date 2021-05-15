using System;

namespace PrayerSoft.Data
{
    public class Configuration : IConfiguration
    {
        public string GetCalendarPath()
        {
            return @"Data\Calendar.csv";
        }

        public string GetMessagesPath()
        {
            return @"Data\Messages.csv";
        }

        public TimeSpan GetMessagesInterval()
        {
            return TimeSpan.FromSeconds(5);
        }

        public string GetImagesPath()
        {
            return "Images";
        }

        public string GetImagesPattern()
        {
            return "*.jpg";
        }

        public TimeSpan GetImagesInterval()
        {
            return TimeSpan.FromSeconds(5);
        }

        public string GetVideosPath()
        {
            return "Videos";
        }

        public string GetVideosPattern()
        {
            return "*.mp4";
        }

        public TimeSpan GetPrayerJamaatInterval()
        {
            return TimeSpan.FromMinutes(5);
        }

        public void Load()
        {
            
        }
    }
}
