﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class RamadanViewModelTests
    {
        private MockClock clock;
        private MockRamadan ramadan;
        private RamadanViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            ramadan = new MockRamadan();
            viewModel = new RamadanViewModel(clock, ramadan);
        }

        [TestMethod]
        public void DisplaysCurrentYear()
        {
            clock.Set(DateTime.Parse("2021-06-19"));

            viewModel.Refresh();

            Assert.AreEqual("Ramadan 2021", viewModel.Title);
        }

        [TestMethod]
        public void DisplayStartAndEndDates()
        {
            ramadan.StartDate = DateTime.Parse("2021-04-13");
            ramadan.EndDate = DateTime.Parse("2021-05-12");

            viewModel.Refresh();

            var expectedStartDate = ramadan.StartDate.ToString("ddddd, dd MMMM");
            var expectedEndDate = ramadan.EndDate.ToString("ddddd, dd MMMM");
            var expectedPeriod = $"{expectedStartDate} - {expectedEndDate}";
            Assert.AreEqual(expectedPeriod, viewModel.Period);
        }

        [TestMethod]
        public void DisplayWhichDayIsToday()
        {
            clock.Set(DateTime.Parse("2021-04-18"));
            ramadan.StartDate = DateTime.Parse("2021-04-13");

            viewModel.Refresh();

            Assert.AreEqual("Today is day 6 of Ramadan", viewModel.Day);
        }
        
        [TestMethod]
        public void DisplaySuhurEnds()
        {
            clock.Set(DateTime.Parse("2021-06-26"));
            ramadan.SuhurEnds = DateTime.Parse("2021-06-26 21:42:00");

            viewModel.Refresh();

            Assert.AreEqual("21:42", viewModel.SuhurEnds);
        }

        [TestMethod]
        public void DisplayIftarBegins()
        {
            clock.Set(DateTime.Parse("2021-06-26"));
            ramadan.IftarBegins = DateTime.Parse("2021-06-26 21:46:00");

            viewModel.Refresh();

            Assert.AreEqual("21:46", viewModel.IftarBegins);
        }

        [TestMethod]
        public void DisplayFirstTaraweeh()
        {
            clock.Set(DateTime.Parse("2021-06-26"));
            ramadan.FirstTaraweeh = DateTime.Parse("2021-06-26 21:51:00");

            viewModel.Refresh();

            Assert.AreEqual("21:51", viewModel.FirstTaraweeh);
        }

        [TestMethod]
        public void DisplaySecondTaraweeh()
        {
            clock.Set(DateTime.Parse("2021-06-26"));
            ramadan.SecondTaraweeh = DateTime.Parse("2021-06-26 21:55:00");

            viewModel.Refresh();

            Assert.AreEqual("21:55", viewModel.SecondTaraweeh);
        }
    }
}