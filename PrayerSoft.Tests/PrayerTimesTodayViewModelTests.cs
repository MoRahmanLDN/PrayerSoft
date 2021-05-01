using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class PrayerTimesTodayViewModelTests
    {
        [TestMethod]
        public void OnRefreshTodaysPrayersAreUpdated()
        {
            var clock = new MockClock();
            var repository = new MockPrayerTimesRepository();

            repository.PrayerTimes = new DailyPrayerTimes
            {
                FajrBegins = new DateTime(2021, 05, 01, 10, 20, 00),
                AsrBegins = new DateTime(2021, 05, 01, 11, 30, 00),
                MaghribBegins = new DateTime(2021, 05, 01, 12, 40, 00),
                IshaBegins = new DateTime(2021, 05, 01, 13, 50, 00),
                FajrJamaat = new DateTime(2021, 05, 01, 14, 22, 00),
                AsrJamaat = new DateTime(2021, 05, 01, 15, 33, 00),
                MaghribJamaat = new DateTime(2021, 05, 01, 16, 44, 00),
                IshaJamaat = new DateTime(2021, 05, 01, 17, 55, 00)
            };
            
            var viewModel = new PrayerTimesTodayViewModel(clock, repository);
            viewModel.Refresh();

            Assert.AreEqual("10:20", viewModel.FajrBegins);
            Assert.AreEqual("11:30", viewModel.AsrBegins);
            Assert.AreEqual("12:40", viewModel.MaghribBegins);
            Assert.AreEqual("13:50", viewModel.IshaBegins);
            Assert.AreEqual("14:22", viewModel.FajrJamaat);
            Assert.AreEqual("15:33", viewModel.AsrJamaat);
            Assert.AreEqual("16:44", viewModel.MaghribJamaat);
            Assert.AreEqual("17:55", viewModel.IshaJamaat);
        }
    }
}
