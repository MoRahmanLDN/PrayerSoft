using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class MessagesViewModelTests
    {   
        private MockClock clock;
        private MockConfiguration configuration;
        private MockMessagesRepository repository;
        private MessagesViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            repository = new MockMessagesRepository();
            configuration = new MockConfiguration();
            configuration.ImagesInterval = TimeSpan.FromSeconds(10);
            viewModel = new MessagesViewModel(clock, configuration, repository);
        }

        [TestMethod]
        public void CanDisplayFirstMessage()
        {
            repository.Message = "Message";

            viewModel.Refresh();

            Assert.AreEqual("Message", viewModel.Current);
        }

        [TestMethod]
        public void ShowsSameMessageWhileIntervalNotPassed()
        {
            repository.Message = "Message1";
            clock.Set(DateTime.Parse("10:00:00"));

            viewModel.Refresh();

            Assert.AreEqual("Message1", viewModel.Current);

            repository.Message = "Message2";
            clock.Set(DateTime.Parse("10:00:05"));

            viewModel.Refresh();

            Assert.AreEqual("Message1", viewModel.Current);
        }

        [TestMethod]
        public void ShowsNextMessageAfterInterval()
        {
            repository.Message = "Message1";
            clock.Set(DateTime.Parse("10:00:00"));

            viewModel.Refresh();

            Assert.AreEqual("Message1", viewModel.Current);

            repository.Message = "Message2";
            clock.Set(DateTime.Parse("10:00:11"));

            viewModel.Refresh();

            Assert.AreEqual("Message2", viewModel.Current);
        }
        
        [TestMethod]
        public void IsVisibleWhenMessagesAvailable()
        {
            repository.Message = "Message";

            viewModel.Refresh();

            Assert.IsTrue(viewModel.IsVisible);
        }

        [TestMethod]
        public void IsNotVisibleWhenNoMessagesAvailable()
        {
            repository.Message = null;

            viewModel.Refresh();

            Assert.IsFalse(viewModel.IsVisible);
        }
    }
}
