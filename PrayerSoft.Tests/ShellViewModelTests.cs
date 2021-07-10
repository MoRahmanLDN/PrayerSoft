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
        private MockRamadan ramadan;
        private ShellViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            clock = new MockClock();
            filesystem = new MockFilesystem();
            configuration = new MockConfiguration();
            configuration.TodayTimetableInterval = TimeSpan.FromHours(20);
            configuration.WeeklyTimetableInterval = TimeSpan.FromSeconds(1);
            configuration.PrayerJamaatInterval = TimeSpan.FromMinutes(20);
            calendar = new MockCalendar();
            calendar.TimesOfDay = new TimesOfDay();
            calendar.Prayers = new List<Prayer>
            {
                new Prayer { Name="Fajr", Begins = DateTime.Parse("10:00"), Jamaat = DateTime.Parse("11:00") },
                new Prayer { Name="Zuhr", Begins = DateTime.Parse("12:00"), Jamaat = DateTime.Parse("13:00") },
                new Prayer { Name="Asr", Begins = DateTime.Parse("14:00"), Jamaat = DateTime.Parse("15:00") },
                new Prayer { Name="Maghrib", Begins = DateTime.Parse("16:00"), Jamaat = DateTime.Parse("17:00") },
                new Prayer { Name="Isha", Begins = DateTime.Parse("18:00"), Jamaat = DateTime.Parse("19:00") }
            };
            ramadan = new MockRamadan();
            viewModel = new ShellViewModel(clock, filesystem, configuration, calendar, ramadan);
        }
        
        [TestMethod]
        public void BeforeAnyPrayerJamaatDisplayScheduleForToday()
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
        public void AfterPrayerJamaatAfterIntervalExpiredDisplayScheduleForToday()
        {
            AssertCurrent(typeof(TodayViewModel), "11:30");
            AssertCurrent(typeof(TodayViewModel), "13:30");
            AssertCurrent(typeof(TodayViewModel), "15:30");
            AssertCurrent(typeof(TodayViewModel), "17:30");
            AssertCurrent(typeof(TodayViewModel), "19:30");
        }

        [TestMethod]
        public void AfterPrayerBeginsBeforeJamaatDisplayPrayerBegins()
        {
            AssertCurrent(typeof(PrayerBeginsViewModel), "10:10");
            AssertCurrent(typeof(PrayerBeginsViewModel), "12:10");
            AssertCurrent(typeof(PrayerBeginsViewModel), "14:10");
            AssertCurrent(typeof(PrayerBeginsViewModel), "16:10");
            AssertCurrent(typeof(PrayerBeginsViewModel), "18:10");
        }

        [TestMethod]
        public void AfterPrayerBeginsAfterVideoEndsDisplayScheduleForToday()
        {
            clock.Set(DateTime.Parse("10:09"));
            viewModel.Refresh();
            var prayerBegins = (PrayerBeginsViewModel)viewModel.Current;
            prayerBegins.HasEnded = true;

            AssertCurrent(typeof(TodayViewModel), "10:10");
        }

        [TestMethod]
        public void DisplayWeeklyTimetableOnRegularIntervals()
        {
            configuration.WeeklyTimetableInterval = TimeSpan.FromMinutes(2);
            configuration.TodayTimetableInterval = TimeSpan.FromMinutes(3);

            AssertCurrent(typeof(TodayViewModel), "09:00:01");
            AssertCurrent(typeof(TodayViewModel), "09:03:00");
            AssertCurrent(typeof(WeeklyScheduleViewModel), "09:03:01");
            AssertCurrent(typeof(WeeklyScheduleViewModel), "09:05:00");
            AssertCurrent(typeof(TodayViewModel), "09:05:01");
            AssertCurrent(typeof(TodayViewModel), "09:08:00");
            AssertCurrent(typeof(WeeklyScheduleViewModel), "09:08:01");
            AssertCurrent(typeof(WeeklyScheduleViewModel), "09:10:00");
        }

        private void AssertCurrent(Type type, string time)
        {   
            clock.Set(DateTime.Parse(time));

            viewModel.Refresh();

            Assert.IsInstanceOfType(viewModel.Current, type);
        }
    }
}
