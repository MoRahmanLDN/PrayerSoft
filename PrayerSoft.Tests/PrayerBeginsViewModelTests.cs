using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class PrayerBeginsViewModelTests
    {
        private PrayerBeginsViewModel viewModel;
        private MockPrayerVideos videos;

        [TestInitialize]
        public void Initialize()
        {
            videos = new MockPrayerVideos();
            viewModel = new PrayerBeginsViewModel(videos);
        }

        [TestMethod]
        public void ShowsVideo()
        {
            videos.Video = "video";

            viewModel.Refresh();

            Assert.AreEqual("video", viewModel.Video);
        }

        [TestMethod]
        public void ResetsHasEndedWhenSwitchingToAnotherVideo()
        {
            videos.Video = "video1";
            viewModel.Refresh();
            viewModel.HasEnded = true;

            videos.Video = "video2";
            viewModel.Refresh();

            Assert.IsFalse(viewModel.HasEnded);
        }
    }
}
