using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using PrayerSoft.Tests.Mocks;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class ShellViewModelTests
    {
        private MockClock clock;
        private MockFilesystem filesystem;
        private MockConfiguration configuration;
        private MockCalendar calendar;
        private ShellViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            filesystem = new MockFilesystem();
            configuration = new MockConfiguration();
            calendar = new MockCalendar();
            calendar.Prayers = new List<Prayer>
            {
                new Prayer { Name="Fajr", Begins = DateTime.Parse("10:00"), Jamaat = DateTime.Parse("11:00") },
                new Prayer { Name="Zuhr", Begins = DateTime.Parse("12:00"), Jamaat = DateTime.Parse("13:00") },
                new Prayer { Name="Asr", Begins = DateTime.Parse("14:00"), Jamaat = DateTime.Parse("15:00") },
                new Prayer { Name="Maghrib", Begins = DateTime.Parse("16:00"), Jamaat = DateTime.Parse("17:00") },
                new Prayer { Name="Isha", Begins = DateTime.Parse("18:00"), Jamaat = DateTime.Parse("19:00") }
            };
            viewModel = new ShellViewModel(clock, filesystem, configuration, calendar);
        }
        
        [TestMethod]
        public void BeforeAnyJamaatDisplayScheduleForToday()
        {
            AssertCurrent(typeof(TodayViewModel), "09:00");
        }

        [TestMethod]
        public void AfterJamaatBeforeIntervalExpiresDisplayPrayerJamaat()
        {
            AssertCurrent(typeof(PrayerJamaatViewModel), "11:10");
            AssertCurrent(typeof(PrayerJamaatViewModel), "13:10");
            AssertCurrent(typeof(PrayerJamaatViewModel), "15:10");
            AssertCurrent(typeof(PrayerJamaatViewModel), "17:10");
            AssertCurrent(typeof(PrayerJamaatViewModel), "19:10");
        }

        [TestMethod]
        public void AfterJamaatAfterIntervalExpiredDisplayScheduleForToday()
        {
            AssertCurrent(typeof(TodayViewModel), "11:30");
            AssertCurrent(typeof(TodayViewModel), "13:30");
            AssertCurrent(typeof(TodayViewModel), "15:30");
            AssertCurrent(typeof(TodayViewModel), "17:30");
            AssertCurrent(typeof(TodayViewModel), "19:30");
        }

        private void AssertCurrent(Type type, string time)
        {
            configuration.PrayerJamaatInterval = TimeSpan.FromMinutes(20);
            clock.Set(DateTime.Parse(time));

            viewModel.Refresh();

            Assert.IsInstanceOfType(viewModel.Current, type);
        }
    }
}
