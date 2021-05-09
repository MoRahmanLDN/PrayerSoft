using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class VideoSequenceViewModelTests
    {
        private MockFileEnumerator enumerator;
        private VideoSequenceViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            enumerator = new MockFileEnumerator();
            enumerator.Files = new List<string> { "video1", "video2" };
            viewModel = new VideoSequenceViewModel(enumerator);
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

        [TestMethod]
        public void SequenceDoesNotEndBeforeLastVideoIsPlayed()
        {
            viewModel.Refresh();
            viewModel.HasCurrentVideoEnded = true;
            viewModel.Refresh();
            viewModel.HasCurrentVideoEnded = false;
            viewModel.Refresh();

            Assert.IsFalse(viewModel.HasEnded);
        }

        [TestMethod]
        public void SequenceEndsWhenLastVideoIsPlayed()
        {
            viewModel.Refresh();
            viewModel.HasCurrentVideoEnded = true;
            viewModel.Refresh();
            viewModel.HasCurrentVideoEnded = true;
            viewModel.Refresh();

            Assert.IsTrue(viewModel.HasEnded);
        }
    }
}
