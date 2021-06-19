using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class RamadanViewModelTests
    {
        [TestMethod]
        public void DisplaysCurrentYear()
        {
            var clock = new MockClock();
            clock.Set(DateTime.Parse("2021-06-19"));

            var viewModel = new RamadanViewModel(clock);
            viewModel.Refresh();

            Assert.AreEqual("Ramadan 2021", viewModel.Title);
        }
    }
}
