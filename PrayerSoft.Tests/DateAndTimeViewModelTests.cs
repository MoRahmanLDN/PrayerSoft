using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class DateAndTimeViewModelTests
    {
        MockClock clock;
        MockConfiguration configuration;
        DateAndTimeViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            configuration = new MockConfiguration();
            viewModel = new DateAndTimeViewModel(clock, configuration);
        }

        [TestMethod]
        public void OnRefreshCurrentTimeIsUpdated()
        {
            var expectedTime = "10:00:00";
            clock.Set(new DateTime(2021, 04, 25, 10, 00, 00));

            viewModel.Refresh();

            var actualTime = viewModel.CurrentTime;
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void OnRefreshCurrentDateIsUpdated()
        {
            var date = new DateTime(2021, 04, 25);
            var expectedDate = date.ToString("ddddd, dd MMMM yyyy");
            clock.Set(date);

            viewModel.Refresh();

            var actualDate = viewModel.CurrentDate;
            Assert.AreEqual(expectedDate, actualDate);
        }

        [TestMethod]
        public void OnRefreshCurrentIslamicDateIsUpdated()
        {
            var expectedDate = "13 Ramadan 1442";
            configuration.HijriAdjustment = -1;
            clock.Set(new DateTime(2021, 04, 25));

            viewModel.Refresh();

            var actualDate = viewModel.CurrentIslamicDate;
            Assert.AreEqual(expectedDate, actualDate);
        }
    }
}
