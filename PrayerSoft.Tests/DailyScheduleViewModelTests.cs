using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class DailyScheduleViewModelTests
    {
        private MockClock clock;
        private MockCalendar calendar;
        private DailyScheduleViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            calendar = new MockCalendar();
            calendar.DailySchedule = new DailySchedule
            {
                FajrBegins = DateTime.Parse("10:20"),
                FajrJamaat = DateTime.Parse("11:21"),

                ZuhrBegins = DateTime.Parse("12:22"),
                ZuhrJamaat = DateTime.Parse("13:23"),

                AsrBegins = DateTime.Parse("14:24"),
                AsrJamaat = DateTime.Parse("15:25"),

                MaghribBegins = DateTime.Parse("16:26"),
                MaghribJamaat = DateTime.Parse("17:27"),

                IshaBegins = DateTime.Parse("18:28"),
                IshaJamaat = DateTime.Parse("19:29"),

                Sunrise = DateTime.Parse("20:30"),
                Sunset = DateTime.Parse("21:31"),
                SubSadiq = DateTime.Parse("22:32"),
                Zawaal = DateTime.Parse("23:33"),
            };

            viewModel = new DailyScheduleViewModel(clock, calendar);
        }

        [TestMethod]
        public void OnRefreshTodaysPrayersAreUpdated()
        {
            viewModel.Refresh();

            Assert.AreEqual("Fajr", viewModel.Prayers[0].PrayerName);
            Assert.AreEqual("10:20", viewModel.Prayers[0].Begins);
            Assert.AreEqual("11:21", viewModel.Prayers[0].Jamaat);

            Assert.AreEqual("Zuhr", viewModel.Prayers[1].PrayerName);
            Assert.AreEqual("12:22", viewModel.Prayers[1].Begins);
            Assert.AreEqual("13:23", viewModel.Prayers[1].Jamaat);

            Assert.AreEqual("Asr", viewModel.Prayers[2].PrayerName);
            Assert.AreEqual("14:24", viewModel.Prayers[2].Begins);
            Assert.AreEqual("15:25", viewModel.Prayers[2].Jamaat);

            Assert.AreEqual("Maghrib", viewModel.Prayers[3].PrayerName);
            Assert.AreEqual("16:26", viewModel.Prayers[3].Begins);
            Assert.AreEqual("17:27", viewModel.Prayers[3].Jamaat);

            Assert.AreEqual("Isha", viewModel.Prayers[4].PrayerName);
            Assert.AreEqual("18:28", viewModel.Prayers[4].Begins);
            Assert.AreEqual("19:29", viewModel.Prayers[4].Jamaat);
            
            Assert.AreEqual("20:30", viewModel.Sunrise);
            Assert.AreEqual("21:31", viewModel.Sunset);
            Assert.AreEqual("22:32", viewModel.SubSadiq);
            Assert.AreEqual("23:33", viewModel.Zawaal);
        }
        
        [TestMethod]
        public void CanMarkFajrAsNextPrayer()
        {
            clock.Set(DateTime.Parse("09:00"));

            viewModel.Refresh();

            Assert.IsTrue(viewModel.Prayers[0].IsNext);
        }

        [TestMethod]
        public void CanMarkZuhrAsNextPrayer()
        {
            clock.Set(DateTime.Parse("13:00"));

            viewModel.Refresh();

            Assert.IsTrue(viewModel.Prayers[1].IsNext);
        }

        [TestMethod]
        public void CanMarkAsrAsNextPrayer()
        {
            clock.Set(DateTime.Parse("15:00"));

            viewModel.Refresh();

            Assert.IsTrue(viewModel.Prayers[2].IsNext);
        }

        [TestMethod]
        public void CanMarkMaghribAsNextPrayer()
        {
            clock.Set(DateTime.Parse("17:00"));

            viewModel.Refresh();

            Assert.IsTrue(viewModel.Prayers[3].IsNext);
        }

        [TestMethod]
        public void CanMarkIshaAsNextPrayer()
        {
            clock.Set(DateTime.Parse("19:00"));

            viewModel.Refresh();

            Assert.IsTrue(viewModel.Prayers[4].IsNext);
        }
    }
}
