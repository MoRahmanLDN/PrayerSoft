using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class VideoSequenceViewModelTests
    {
        private MockFileRepository repository;
        private VideoSequenceViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            repository = new MockFileRepository();
            repository.Files = new List<string> { "video1", "video2" };
            viewModel = new VideoSequenceViewModel(repository);
        }

        [TestMethod]
        public void CanPlayFirstVideo()
        {   
            viewModel.Refresh();

            Assert.AreEqual("video1", viewModel.Video);
        }

        [TestMethod]
        public void CanPlayNextVideo()
        {
            viewModel.Refresh();
            viewModel.HasCurrentVideoEnded = true;

            viewModel.Refresh();

            Assert.AreEqual("video2", viewModel.Video);
        }
    }
}
