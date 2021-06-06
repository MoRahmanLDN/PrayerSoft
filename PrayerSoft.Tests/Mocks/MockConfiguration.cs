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
        public TimeSpan PrayerJamaatInterval { get; set; }
        public TimeSpan WeeklyTimetableInterval { get; internal set; }
        public TimeSpan TodayTimetableInterval { get; internal set; }

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

        public TimeSpan GetPrayerJamaatInterval()
        {
            return PrayerJamaatInterval;
        }

        public TimeSpan GetWeeklyTimetableInterval()
        {
            return WeeklyTimetableInterval;
        }

        public TimeSpan GetTodayTimetableInterval()
        {
            return TodayTimetableInterval;
        }

        public void Load()
        {
        }
    }
}