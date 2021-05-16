using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;
using System.Collections.Generic;

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
            calendar.Prayers = new List<Prayer>
            {
                new Prayer { Name="Fajr", Jamaat = DateTime.Parse("23:59:59") },
                new Prayer { Name="Zuhr", Jamaat = DateTime.Parse("23:59:59") },
                new Prayer { Name="Asr", Jamaat = DateTime.Parse("23:59:59") },
                new Prayer { Name="Maghrib", Jamaat = DateTime.Parse("23:59:59") },
                new Prayer { Name="Isha", Jamaat = DateTime.Parse("23:59:59") }
            };

            viewModel = new CountdownViewModel(clock, calendar);
        }

        [TestMethod]
        public void CountdownForFajrJamaat()
        {
            calendar.Prayers[0].Jamaat = DateTime.Parse("10:02:03");

            viewModel.Refresh();

            Assert.AreEqual("00:02:03", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForZuhrJamaat()
        {
            calendar.Prayers[0].Jamaat = DateTime.Parse("09:00:00");
            calendar.Prayers[1].Jamaat = DateTime.Parse("11:12:13");

            viewModel.Refresh();

            Assert.AreEqual("01:12:13", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForAsrJamaat()
        {
            calendar.Prayers[0].Jamaat = DateTime.Parse("09:10:00");
            calendar.Prayers[1].Jamaat = DateTime.Parse("09:20:00");
            calendar.Prayers[2].Jamaat = DateTime.Parse("12:22:23");

            viewModel.Refresh();

            Assert.AreEqual("02:22:23", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForMaghribJamaat()
        {
            calendar.Prayers[0].Jamaat = DateTime.Parse("09:10:00");
            calendar.Prayers[1].Jamaat = DateTime.Parse("09:20:00");
            calendar.Prayers[2].Jamaat = DateTime.Parse("09:30:00");
            calendar.Prayers[3].Jamaat = DateTime.Parse("13:32:33");

            viewModel.Refresh();

            Assert.AreEqual("03:32:33", viewModel.Remaining);
        }

        [TestMethod]
        public void CountdownForIshaJamaat()
        {
            calendar.Prayers[0].Jamaat = DateTime.Parse("09:10:00");
            calendar.Prayers[1].Jamaat = DateTime.Parse("09:20:00");
            calendar.Prayers[2].Jamaat = DateTime.Parse("09:30:00");
            calendar.Prayers[3].Jamaat = DateTime.Parse("09:40:00");
            calendar.Prayers[4].Jamaat = DateTime.Parse("14:42:43");

            viewModel.Refresh();

            Assert.AreEqual("04:42:43", viewModel.Remaining);
        }
    }
}
