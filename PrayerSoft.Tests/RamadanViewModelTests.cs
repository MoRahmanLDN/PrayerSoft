using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class RamadanViewModelTests
    {
        private MockClock clock;
        private MockRamadan ramadan;
        private RamadanViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            ramadan = new MockRamadan();
            viewModel = new RamadanViewModel(clock, ramadan);
        }

        [TestMethod]
        public void DisplaysCurrentYear()
        {
            clock.Set(DateTime.Parse("2021-06-19"));

            viewModel.Refresh();

            Assert.AreEqual("Ramadan 2021", viewModel.Title);
        }

        [TestMethod]
        public void DisplayStartAndEndDates()
        {
            ramadan.StartDate = DateTime.Parse("2021-04-13");
            ramadan.EndDate = DateTime.Parse("2021-05-12");

            viewModel.Refresh();

            var expectedStartDate = ramadan.StartDate.ToString("ddddd, dd MMMM");
            var expectedEndDate = ramadan.EndDate.ToString("ddddd, dd MMMM");
            var expectedPeriod = $"{expectedStartDate} - {expectedEndDate}";
            Assert.AreEqual(expectedPeriod, viewModel.Period);
        }
    }
}
