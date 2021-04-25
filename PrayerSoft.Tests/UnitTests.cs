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
        public void OnRefreshCurrentTimeIsDisplayed()
        {
            var expectedTime = "10:00:00";
            clock.SetTime(expectedTime);

            viewModel.Refresh();

            var actualTime = viewModel.CurrentTime;
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void OnRefreshCurrentDateIsDisplayed()
        {
            var expectedDate = "Sunday, 25 April 2021";
            clock.SetDate(expectedDate);

            viewModel.Refresh();

            var actualDate = viewModel.CurrentDate;
            Assert.AreEqual(expectedDate, actualDate);
        }
    }
}
