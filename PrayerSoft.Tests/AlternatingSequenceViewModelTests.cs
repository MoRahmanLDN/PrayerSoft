using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class AlternatingSequenceViewModelTests
    {
        private MockSequenceViewModel firstSequence;
        private MockSequenceViewModel secondSequence;
        private AlternatingSequenceViewModel alternatingSequence;

        [TestInitialize]
        public void Initialize()
        {
            firstSequence = new MockSequenceViewModel();
            secondSequence = new MockSequenceViewModel();
            alternatingSequence = new AlternatingSequenceViewModel(firstSequence, secondSequence);
        }

        [TestMethod]
        public void ShowFirstSequenceByDefault()
        {
            alternatingSequence.Refresh();

            Assert.AreEqual(firstSequence, alternatingSequence.Current);
            Assert.IsTrue(firstSequence.IsRefreshed);
        }

        [TestMethod]
        public void ShowSecondSequenceAfterFirst()
        {
            firstSequence.HasEnded = true;

            alternatingSequence.Refresh();
            
            Assert.AreEqual(secondSequence, alternatingSequence.Current);
            Assert.IsTrue(secondSequence.IsReset);
            Assert.IsTrue(secondSequence.IsRefreshed);
        }

        [TestMethod]
        public void ShowFirstSequenceAfterSecond()
        {
            firstSequence.HasEnded = true;
            alternatingSequence.Refresh();

            secondSequence.HasEnded = true;
            alternatingSequence.Refresh();

            Assert.AreEqual(firstSequence, alternatingSequence.Current);
            Assert.IsTrue(firstSequence.IsReset);
            Assert.IsTrue(firstSequence.IsRefreshed);
        }
    }
}
