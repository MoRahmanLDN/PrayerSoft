using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class MosqueViewModelTests
    {
        [TestMethod]
        public void DisplaysMosqueNameCorrectly()
        {
            var configuration = new MockConfiguration();
            configuration.MosqueName = "Mosque";

            var viewModel = new MosqueViewModel(configuration);

            viewModel.Refresh();

            Assert.AreEqual("Mosque", viewModel.Name);
        }
    }
}
