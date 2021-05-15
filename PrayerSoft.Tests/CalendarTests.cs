using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class CalendarTests
    {
        private MockFileSystem filesystem;
        private Configuration configuration;
        private Calendar calendar;

        [TestInitialize]
        public void Initialize() 
        {
            filesystem = new MockFileSystem();
            calendar = new Calendar(filesystem, configuration);
        }

        [TestMethod]
        public void ParsesCorrectlyCsv()
        {
            filesystem.FileContent =
                "Date,FajrBegins,FajrJamaat,ZuhrBegins,ZuhrJamaat,AsrBegins,AsrJamaat,MaghribBegins,MaghribJamaat,IshaBegins,IshaJamaat,Sunrise,Sunset,SubSadiq,Zawaal\r\n" +
                "2022-05-01,10:20,10:30,10:40,10:50,11:00,11:10,11:20,11:30,11:40,11:50,01:01,02:02,03:03,04:04\r\n";

            calendar.Load();

            var dailyPrayers = calendar.Get(new DateTime(2022, 05, 01));

            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 20, 00), dailyPrayers.FajrBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 30, 00), dailyPrayers.FajrJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 40, 00), dailyPrayers.ZuhrBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 50, 00), dailyPrayers.ZuhrJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 00, 00), dailyPrayers.AsrBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 10, 00), dailyPrayers.AsrJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 20, 00), dailyPrayers.MaghribBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 30, 00), dailyPrayers.MaghribJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 40, 00), dailyPrayers.IshaBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 50, 00), dailyPrayers.IshaJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 01, 01, 00), dailyPrayers.Sunrise);
            Assert.AreEqual(new DateTime(2022, 05, 01, 02, 02, 00), dailyPrayers.Sunset);
            Assert.AreEqual(new DateTime(2022, 05, 01, 03, 03, 00), dailyPrayers.SubSadiq);
            Assert.AreEqual(new DateTime(2022, 05, 01, 04, 04, 00), dailyPrayers.Zawaal);
        }
    }
}
