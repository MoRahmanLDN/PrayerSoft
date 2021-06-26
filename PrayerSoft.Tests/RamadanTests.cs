using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class RamadanTests
    {
        private MockFilesystem filesystem;
        private MockConfiguration configuration;
        private Ramadan ramadan;

        [TestInitialize]
        public void Initialize()
        {
            filesystem = new MockFilesystem();
            configuration = new MockConfiguration();
            ramadan = new Ramadan(filesystem, configuration);
        }

        [TestMethod]
        public void GetsCorrectStartAndEndDates()
        {
            filesystem.FileContent =
                "Date,SuhurEnds,IftarBegins,FirstTaraweeh,SecondTaraweeh\r\n" +
                "2021-06-26,10:20,11:30,12:40,13:50\r\n" +
                "2021-06-27,10:20,11:30,12:40,13:50\r\n" +
                "2021-06-28,10:20,11:30,12:40,13:50";

            ramadan.Load();

            var startDate = ramadan.GetStartDate();
            Assert.AreEqual(DateTime.Parse("2021-06-26"), startDate);

            var endDate = ramadan.GetEndDate();
            Assert.AreEqual(DateTime.Parse("2021-06-28"), endDate);
        }

        [TestMethod]
        public void GetCorrectPrayerTimes()
        {
            filesystem.FileContent =
                "Date,SuhurEnds,IftarBegins,FirstTaraweeh,SecondTaraweeh\r\n" +
                "2021-06-25,10:20,11:30,12:40,13:50\r\n" +
                "2021-06-26,12:10,13:20,14:30,15:40\r\n" +
                "2021-06-27,10:20,11:30,12:40,13:50";

            ramadan.Load();

            var date = DateTime.Parse("2021-06-26");
            
            var suhurEnds = ramadan.GetSuhurEnds(date);
            AssertAreEqual(date, DateTime.Parse("12:10"), suhurEnds);

            var iftarBegins = ramadan.GetIftarBegins(date);
            AssertAreEqual(date, DateTime.Parse("13:20"), iftarBegins);

            var firstTaraweeh = ramadan.GetFirstTaraweeh(date);
            AssertAreEqual(date, DateTime.Parse("14:30"), firstTaraweeh);

            var secondTaraweeh = ramadan.GetSecondTaraweeh(date);
            AssertAreEqual(date, DateTime.Parse("15:40"), secondTaraweeh);
        }

        private void AssertAreEqual(DateTime expectedDate, DateTime expectedTime, DateTime actual)
        {
            Assert.AreEqual(new DateTime(expectedDate.Year, expectedDate.Month, expectedDate.Day, expectedTime.Hour, expectedTime.Minute, expectedTime.Second), actual);
        }
    }
}
