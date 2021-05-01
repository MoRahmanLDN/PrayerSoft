﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class DailyPrayerTimesRepositoryTests
    {
        [TestMethod]
        public void ParsesCorrectlyCsv()
        {
            var csv =
                "Date,FajrBegins,FajrJamaat,AsrBegins,AsrJamaat,MaghribBegins,MaghribJamaat,IshaBegins,IshaJamaat\r\n" +
                "2022-05-01,10:20,10:30,10:40,10:50,11:00,11:10,11:20,11:30\r\n";

            var repository = new DailyPrayerTimesRepository();
            repository.Load(csv);
            var dailyPrayers = repository.Get(new DateTime(2022, 05, 01));

            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 20, 00), dailyPrayers.FajrBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 30, 00), dailyPrayers.FajrJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 40, 00), dailyPrayers.AsrBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 10, 50, 00), dailyPrayers.AsrJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 00, 00), dailyPrayers.MaghribBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 10, 00), dailyPrayers.MaghribJamaat);

            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 20, 00), dailyPrayers.IshaBegins);
            Assert.AreEqual(new DateTime(2022, 05, 01, 11, 30, 00), dailyPrayers.IshaJamaat);
        }
    }
}