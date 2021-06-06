using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class WeeklyTimetableViewModelTests
    {
        [TestMethod]
        public void LoadsAndDisplaysDataCorrectly()
        {
            var clock = new MockClock();
            clock.Set(DateTime.Parse("2021-06-06"));

            var calendar = new MockCalendar();
            calendar.Prayers = new List<Prayer>
            {
                new Prayer{Begins = DateTime.Parse("10:00"), Jamaat = DateTime.Parse("10:10")},
                new Prayer{Begins = DateTime.Parse("11:00"), Jamaat = DateTime.Parse("11:10")},
                new Prayer{Begins = DateTime.Parse("12:00"), Jamaat = DateTime.Parse("12:10")},
                new Prayer{Begins = DateTime.Parse("13:00"), Jamaat = DateTime.Parse("13:10")},
                new Prayer{Begins = DateTime.Parse("14:00"), Jamaat = DateTime.Parse("14:10")},
            };
            
            var viewModel = new WeeklyTimetableViewModel(clock, calendar);

            viewModel.Refresh();

            Assert.AreEqual(7, viewModel.WeeklyPrayers.Count);
            Assert.AreEqual("Sunday", viewModel.WeeklyPrayers[0].DayOfWeek);
            Assert.AreEqual("Monday", viewModel.WeeklyPrayers[1].DayOfWeek);
            Assert.AreEqual("Tuesday", viewModel.WeeklyPrayers[2].DayOfWeek);
            Assert.AreEqual("Wednesday", viewModel.WeeklyPrayers[3].DayOfWeek);
            Assert.AreEqual("Thursday", viewModel.WeeklyPrayers[4].DayOfWeek);
            Assert.AreEqual("Friday", viewModel.WeeklyPrayers[5].DayOfWeek);
            Assert.AreEqual("Saturday", viewModel.WeeklyPrayers[6].DayOfWeek);

            for (int i=0; i<7; i++)
            {
                Assert.AreEqual("10:00", viewModel.WeeklyPrayers[i].Prayers[0].Begins);
                Assert.AreEqual("10:10", viewModel.WeeklyPrayers[i].Prayers[0].Jamaat);
                Assert.AreEqual("11:00", viewModel.WeeklyPrayers[i].Prayers[1].Begins);
                Assert.AreEqual("11:10", viewModel.WeeklyPrayers[i].Prayers[1].Jamaat);
                Assert.AreEqual("12:00", viewModel.WeeklyPrayers[i].Prayers[2].Begins);
                Assert.AreEqual("12:10", viewModel.WeeklyPrayers[i].Prayers[2].Jamaat);
                Assert.AreEqual("13:00", viewModel.WeeklyPrayers[i].Prayers[3].Begins);
                Assert.AreEqual("13:10", viewModel.WeeklyPrayers[i].Prayers[3].Jamaat);
                Assert.AreEqual("14:00", viewModel.WeeklyPrayers[i].Prayers[4].Begins);
                Assert.AreEqual("14:10", viewModel.WeeklyPrayers[i].Prayers[4].Jamaat);
            }
        }
    }
}
