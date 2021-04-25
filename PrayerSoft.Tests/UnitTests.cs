using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class UnitTests
    {
        MockClock clock;
        CurrentTimeViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            viewModel = new CurrentTimeViewModel(clock);
        }

        [TestMethod]
        public void OnRefreshCurrentTimeIsUpdated()
        {
            var expectedTime = "10:00:00";
            clock.SetTime(expectedTime);

            viewModel.Refresh();

            var actualTime = viewModel.CurrentTime;
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void OnRefreshCurrentDateIsUpdated()
        {
            var expectedDate = "Sunday, 25 April 2021";
            clock.SetDate(expectedDate);

            viewModel.Refresh();

            var actualDate = viewModel.CurrentDate;
            Assert.AreEqual(expectedDate, actualDate);
        }

        [TestMethod]
        public void OnRefreshCurrentIslamicDateIsUpdated()
        {
            var expectedDate = "13 Ramadan 1442";
            clock.SetIslamicDate(expectedDate);

            viewModel.Refresh();

            var actualDate = viewModel.CurrentIslamicDate;
            Assert.AreEqual(expectedDate, actualDate);
        }
    }
}
