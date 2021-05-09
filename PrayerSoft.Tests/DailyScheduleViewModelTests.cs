using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class DailyScheduleViewModelTests
    {
        [TestMethod]
        public void OnRefreshTodaysPrayersAreUpdated()
        {
            var clock = new MockClock();
            var calendar = new MockCalendar();

            calendar.DailySchedule = new DailySchedule
            {
                FajrBegins = new DateTime(2021, 05, 01, 10, 20, 00),
                FajrJamaat = new DateTime(2021, 05, 01, 14, 22, 00),

                AsrBegins = new DateTime(2021, 05, 01, 11, 30, 00),
                AsrJamaat = new DateTime(2021, 05, 01, 15, 33, 00),

                MaghribBegins = new DateTime(2021, 05, 01, 12, 40, 00),
                MaghribJamaat = new DateTime(2021, 05, 01, 16, 44, 00),

                IshaBegins = new DateTime(2021, 05, 01, 13, 50, 00),
                IshaJamaat = new DateTime(2021, 05, 01, 17, 55, 00),

                Sunrise = new DateTime(2021, 05, 01, 01, 01, 00),
                Sunset = new DateTime(2021, 05, 01, 02, 02, 00),
                SubSadiq = new DateTime(2021, 05, 01, 03, 03, 00),
                Zawaal = new DateTime(2021, 05, 01, 04, 04, 00),
            };
            
            var viewModel = new DailyScheduleViewModel(clock, calendar);
            viewModel.Refresh();

            Assert.AreEqual("10:20", viewModel.Fajr.Begins);
            Assert.AreEqual("14:22", viewModel.Fajr.Jamaat);

            Assert.AreEqual("11:30", viewModel.Asr.Begins);
            Assert.AreEqual("15:33", viewModel.Asr.Jamaat);

            Assert.AreEqual("12:40", viewModel.Maghrib.Begins);
            Assert.AreEqual("16:44", viewModel.Maghrib.Jamaat);

            Assert.AreEqual("13:50", viewModel.Isha.Begins);
            Assert.AreEqual("17:55", viewModel.Isha.Jamaat);
            
            Assert.AreEqual("01:01", viewModel.Sunrise);
            Assert.AreEqual("02:02", viewModel.Sunset);
            Assert.AreEqual("03:03", viewModel.SubSadiq);
            Assert.AreEqual("04:04", viewModel.Zawaal);
        }
    }
}
