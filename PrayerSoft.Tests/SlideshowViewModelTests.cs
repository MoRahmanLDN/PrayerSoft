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
        MockFileEnumerator repository;
        SlideshowViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            repository = new MockFileEnumerator();
            viewModel = new SlideshowViewModel(clock, repository, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenFirstShownDisplayFirstImage()
        {
            repository.Files = new List<string> { "image" };

            viewModel.Refresh();

            Assert.AreEqual("image", viewModel.Image);
        }

        [TestMethod]
        public void WhenTimeElapsedDisplayNextImage()
        {
            repository.Files = new List<string> { "image1", "image2" };

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 00));
            viewModel.Refresh();

            Assert.AreEqual("image1", viewModel.Image);

            clock.Set(new DateTime(2021, 05, 02, 19, 01, 10));
            viewModel.Refresh();

            Assert.AreEqual("image2", viewModel.Image);
        }
    }
}
