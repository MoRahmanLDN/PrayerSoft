using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void OnRefreshCurrentTimeIsDisplayed()
        {
            var expectedTime = "10:00:00";
            var clock = new MockClock();
            clock.SetTime(expectedTime);

            var currentTimeViewModel = new CurrentTimeViewModel(clock);
            currentTimeViewModel.Refresh();

            var actualTime = currentTimeViewModel.CurrentTime;
            Assert.AreEqual(expectedTime, actualTime);
        }
    }
}
