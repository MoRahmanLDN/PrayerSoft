using Newtonsoft.Json;
using System;

namespace PrayerSoft.Data
{
    public class Configuration : IConfiguration
    {
        private IFilesystem filesystem;
        private dynamic settings;

        public Configuration(IFilesystem filesystem)
        {
            this.filesystem = filesystem;
        }

        public void Load()
        {
            var settingsString = filesystem.Read("settings.json");
            settings = JsonConvert.DeserializeObject(settingsString);
        }

        public string GetCalendarPath()
        {
            return settings.CalendarPath.Value;
        }
        
        public string GetRamadanPath()
        {
            return settings.RamadanPath.Value;
        }

        public string GetMessagesPath()
        {
            return settings.Messages.Path.Value;
        }

        public TimeSpan GetMessagesInterval()
        {
            return TimeSpan.Parse(settings.Messages.Interval.Value);
        }

        public string GetImagesPath()
        {
            return settings.Images.Path.Value;
        }

        public string GetImagesPattern()
        {
            return settings.Images.Pattern.Value;
        }

        public TimeSpan GetImagesInterval()
        {
            return TimeSpan.Parse(settings.Images.Interval.Value);
        }

        public string GetVideosPath()
        {
            return settings.Videos.Path.Value;
        }

        public string GetVideosPattern()
        {
            return settings.Videos.Pattern.Value;
        }

        public TimeSpan GetPrayerJamaatInterval()
        {
            return TimeSpan.Parse(settings.PrayerJamaatInterval.Value);
        }

        public TimeSpan GetWeeklyTimetableInterval()
        {
            return TimeSpan.Parse(settings.WeeklyTimetableInterval.Value);
        }

        public TimeSpan GetTodayTimetableInterval()
        {
            return TimeSpan.Parse(settings.TodayTimetableInterval.Value);
        }

        public DateTime GetEidUlFitr()
        {
            return DateTime.Parse(settings.EidUlFitr.Value);
        }

        public DateTime GetEidUlAdha()
        {
            return DateTime.Parse(settings.EidUlAdha.Value);
        }
    }
}
