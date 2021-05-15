using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockConfiguration : IConfiguration
    {
        public string CalendarPath { get; set; }
        public string ImagesPath { get; set; }
        public string ImagesPattern { get; set; }
        public TimeSpan ImagesInterval { get; set; }
        public string VideosPath { get; set; }
        public string VideosPattern { get; set; }
        public string MessagesPath { get; set; }
        public TimeSpan MessagesInterval { get; set; }

        public string GetCalendarPath()
        {
            return CalendarPath;
        }

        public TimeSpan GetImagesInterval()
        {
            return ImagesInterval;
        }

        public string GetImagesPath()
        {
            return ImagesPath;
        }

        public string GetImagesPattern()
        {
            return ImagesPattern;
        }

        public TimeSpan GetMessagesInterval()
        {
            return MessagesInterval;
        }

        public string GetMessagesPath()
        {
            return MessagesPath;
        }

        public string GetVideosPath()
        {
            return VideosPath;
        }

        public string GetVideosPattern()
        {
            return VideosPattern;
        }
    }
}