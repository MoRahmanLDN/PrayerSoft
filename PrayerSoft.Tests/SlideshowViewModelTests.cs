using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class SlideshowViewModelTests
    {
        MockClock clock;
        MockFileEnumerator enumerator;
        ImageSequenceViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            enumerator = new MockFileEnumerator();
            viewModel = new ImageSequenceViewModel(clock, enumerator, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenFirstShownDisplayFirstImage()
        {
            enumerator.Files = new List<string> { "image" };

            viewModel.Refresh();

            Assert.AreEqual("image", viewModel.Image);
        }

        [TestMethod]
        public void WhenTimeElapsedDisplayNextImage()
        {
            enumerator.Files = new List<string> { "image1", "image2" };

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 00));
            viewModel.Refresh();

            Assert.AreEqual("image1", viewModel.Image);

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 10));
            viewModel.Refresh();

            Assert.AreEqual("image2", viewModel.Image);
        }

        [TestMethod]
        public void SequenceDoesNotEndBeforeTimeElapsesForLastImage()
        {
            enumerator.Files = new List<string> { "image1", "image2" };

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 00));
            viewModel.Refresh();

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 10));
            viewModel.Refresh();

            Assert.IsFalse(viewModel.HasEnded);
        }

        [TestMethod]
        public void SequenceEndsWhenTimeElapsesForLastImage()
        {
            enumerator.Files = new List<string> { "image1", "image2" };

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 00));
            viewModel.Refresh();

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 10));
            viewModel.Refresh();

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 20));
            viewModel.Refresh();

            Assert.IsTrue(viewModel.HasEnded);
        }
    }
}
