using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class CalendarTests
    {
        private MockFilesystem filesystem;
        private MockConfiguration configuration;
        private Calendar calendar;

        [TestInitialize]
        public void Initialize() 
        {
            filesystem = new MockFilesystem();
            configuration = new MockConfiguration();
            calendar = new Calendar(filesystem, configuration);
        }

        [TestMethod]
        public void ParsesCorrectlyCsv()
        {
            filesystem.FileContent =
                "Date,FajrBegins,FajrJamaat,ZuhrBegins,ZuhrJamaat,AsrBegins,AsrJamaat,MaghribBegins,MaghribJamaat,IshaBegins,IshaJamaat,Sunrise,Sunset,SubSadiq,Zawaal\r\n" +
                "2022-05-01,10:20,10:30,10:40,10:50,11:00,11:10,11:20,11:30,11:40,11:50,01:01,02:02,03:03,04:04\r\n";

            calendar.Load();

            var prayers = calendar.GetPrayers(new DateTime(2022, 05, 01));

            Assert.AreEqual("Fajr", prayers[0].Name);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 20, 00), prayers[0].Begins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 30, 00), prayers[0].Jamaat);

            Assert.AreEqual("Zuhr", prayers[1].Name);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 40, 00), prayers[1].Begins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 50, 00), prayers[1].Jamaat);

            Assert.AreEqual("Asr", prayers[2].Name);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 00, 00), prayers[2].Begins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 10, 00), prayers[2].Jamaat);

            Assert.AreEqual("Maghrib", prayers[3].Name);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 20, 00), prayers[3].Begins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 30, 00), prayers[3].Jamaat);

            Assert.AreEqual("Isha", prayers[4].Name);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 40, 00), prayers[4].Begins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 50, 00), prayers[4].Jamaat);

            var timesOfDay = calendar.GetTimesOfDay(new DateTime(2022, 05, 01));

            Assert.AreEqual(new DateTime(2022, 05, 01, 01, 01, 00), timesOfDay.Sunrise);
            Assert.AreEqual(new DateTime(2022, 05, 01, 02, 02, 00), timesOfDay.Sunset);
            Assert.AreEqual(new DateTime(2022, 05, 01, 03, 03, 00), timesOfDay.SubSadiq);
            Assert.AreEqual(new DateTime(2022, 05, 01, 04, 04, 00), timesOfDay.Zawaal);
        }
    }
}
