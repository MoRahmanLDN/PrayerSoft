using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Utilities;
using System.Linq;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class CycleTests
    {
        [TestMethod]
        public void EmptyCycle()
        {
            var cycle = Cycle.Get(0, 0);

            Assert.IsFalse(cycle.Any());
        }

        [TestMethod]
        public void CycleWithOneElement()
        {
            var cycle = Cycle.Get(0, 1);

            Assert.AreEqual(0, cycle.Single());
        }

        [TestMethod]
        public void CycleWithTwoElements()
        {
            var cycle = Cycle.Get(0, 2).ToList();

            Assert.AreEqual(0, cycle[0]);
            Assert.AreEqual(1, cycle[1]);
        }

        [TestMethod]
        public void CycleWithTwoElementsStartingAtSecondElement()
        {
            var cycle = Cycle.Get(1, 2).ToList();

            Assert.AreEqual(1, cycle[0]);
            Assert.AreEqual(0, cycle[1]);
        }

        [TestMethod]
        public void CycleWithMultipleElements()
        {
            var cycle = Cycle.Get(4, 7).ToList();

            Assert.AreEqual(4, cycle[0]);
            Assert.AreEqual(5, cycle[1]);
            Assert.AreEqual(6, cycle[2]);
            Assert.AreEqual(0, cycle[3]);
            Assert.AreEqual(1, cycle[4]);
            Assert.AreEqual(2, cycle[5]);
            Assert.AreEqual(3, cycle[6]);
        }
    }
}
