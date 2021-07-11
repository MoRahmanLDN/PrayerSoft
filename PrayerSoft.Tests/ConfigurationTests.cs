using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void ParsesCorrectlyJson()
        {
            var filesystem = new MockFilesystem();
            filesystem.FileContent = @"{
              ""MosqueName"" : ""Mosque"",
              ""CalendarPath"": ""Data\\Calendar.csv"",
              ""RamadanPath"": ""Data\\Ramadan.csv"",
              ""Messages"": {
                ""Path"": ""Data\\Messages.csv"",
                ""Interval"": ""00:00:05""
              },
              ""Images"": {
                ""Path"": ""Images"",
                ""Pattern"": ""*.jpg"",
                ""Interval"": ""00:00:05""
              },
              ""Videos"": {
                ""Path"": ""Videos"",
                ""Pattern"": ""*.mp4""
              },
              ""PrayerJamaatInterval"": ""00:05:00"",
              ""TodayTimetableInterval"": ""00:03:00"",
              ""WeeklyTimetableInterval"": ""00:02:00"",
              ""EidUlFitr"": ""2021-05-13"",
              ""EidUlAdha"": ""2021-07-19""
            }";

            var configuration = new Configuration(filesystem);
            configuration.Load();

            Assert.AreEqual("Mosque", configuration.GetMosqueName());
            Assert.AreEqual("Data\\Calendar.csv", configuration.GetCalendarPath());
            Assert.AreEqual("Data\\Ramadan.csv", configuration.GetRamadanPath());
            Assert.AreEqual("Data\\Messages.csv", configuration.GetMessagesPath());
            Assert.AreEqual(TimeSpan.Parse("00:00:05"), configuration.GetMessagesInterval());
            Assert.AreEqual("Images", configuration.GetImagesPath());
            Assert.AreEqual("*.jpg", configuration.GetImagesPattern());
            Assert.AreEqual(TimeSpan.Parse("00:00:05"), configuration.GetImagesInterval());
            Assert.AreEqual("Videos", configuration.GetVideosPath());
            Assert.AreEqual("*.mp4", configuration.GetVideosPattern());
            Assert.AreEqual(TimeSpan.Parse("00:05:00"), configuration.GetPrayerJamaatInterval());
            Assert.AreEqual(TimeSpan.Parse("00:03:00"), configuration.GetTodayTimetableInterval());
            Assert.AreEqual(TimeSpan.Parse("00:02:00"), configuration.GetWeeklyTimetableInterval());
            Assert.AreEqual(DateTime.Parse("2021-05-13"), configuration.GetEidUlFitr());
            Assert.AreEqual(DateTime.Parse("2021-07-19"), configuration.GetEidUlAdha());
        }
    }
}
