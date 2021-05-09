using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class CountdownViewModelTests
    {
        private CountdownViewModel viewModel;
        private MockClock clock;
        private MockCalendar calendar;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            clock.Set(DateTime.Parse("10:00:00"));

            calendar = new MockCalendar();
            calendar.DailySchedule = new DailySchedule
            {
                AsrJamaat = DateTime.Parse("23:59:59"),
                ZuhrJamaat = DateTime.Parse("23:59:59"),
                FajrJamaat = DateTime.Parse("23:59:59"),
                MaghribJamaat = DateTime.Parse("23:59:59"),
                IshaJamaat = DateTime.Parse("23:59:59"),
            };

            viewModel = new CountdownViewModel(clock, calendar);
        }

        [TestMethod]
        public void CountdownForFajrJamaat()
        {
            calendar.DailySchedule.FajrJamaat = DateTime.Parse("10:02:03");

            viewModel.Refresh();

            Assert.AreEqual("00:02:03", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForZuhrJamaat()
        {
            calendar.DailySchedule.FajrJamaat = DateTime.Parse("09:00:00");
            calendar.DailySchedule.ZuhrJamaat = DateTime.Parse("11:12:13");

            viewModel.Refresh();

            Assert.AreEqual("01:12:13", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForAsrJamaat()
        {
            calendar.DailySchedule.FajrJamaat = DateTime.Parse("09:10:00");
            calendar.DailySchedule.ZuhrJamaat = DateTime.Parse("09:20:00");
            calendar.DailySchedule.AsrJamaat = DateTime.Parse("12:22:23");

            viewModel.Refresh();

            Assert.AreEqual("02:22:23", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForMaghribJamaat()
        {
            calendar.DailySchedule.FajrJamaat = DateTime.Parse("09:10:00");
            calendar.DailySchedule.ZuhrJamaat = DateTime.Parse("09:20:00");
            calendar.DailySchedule.AsrJamaat = DateTime.Parse("09:30:00");
            calendar.DailySchedule.MaghribJamaat = DateTime.Parse("13:32:33");

            viewModel.Refresh();

            Assert.AreEqual("03:32:33", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForIshaJamaat()
        {
            calendar.DailySchedule.FajrJamaat = DateTime.Parse("09:10:00");
            calendar.DailySchedule.ZuhrJamaat = DateTime.Parse("09:20:00");
            calendar.DailySchedule.AsrJamaat = DateTime.Parse("09:30:00");
            calendar.DailySchedule.MaghribJamaat = DateTime.Parse("09:40:00");
            calendar.DailySchedule.IshaJamaat = DateTime.Parse("14:42:43");

            viewModel.Refresh();

            Assert.AreEqual("04:42:43", viewModel.Remaining);
        }
    }
}
