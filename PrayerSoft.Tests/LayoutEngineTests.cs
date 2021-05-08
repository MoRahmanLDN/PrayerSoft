using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class LayoutEngineTests
    {
        private MockSequenceViewModel first;
        private MockSequenceViewModel second;
        private LayoutEngine engine;

        [TestInitialize]
        public void Initialize()
        {
            first = new MockSequenceViewModel();
            second = new MockSequenceViewModel();
            engine = new LayoutEngine(first, second);
        }

        [TestMethod]
        public void ShowFirstByDefault()
        {
            var viewModel = engine.Choose();

            Assert.AreEqual(first, viewModel);
        }

        [TestMethod]
        public void ShowSecondAfterFirst()
        {
            first.HasEnded = true;

            var viewModel = engine.Choose();
            
            Assert.AreEqual(second, viewModel);
            Assert.IsTrue(second.IsReset);
        }

        [TestMethod]
        public void ShowFirstAfterSecond()
        {
            first.HasEnded = true;
            engine.Choose();

            second.HasEnded = true;
            var viewModel = engine.Choose();

            Assert.AreEqual(first, viewModel);
            Assert.IsTrue(first.IsReset);
        }
    }
}
