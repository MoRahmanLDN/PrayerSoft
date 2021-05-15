using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Tests.Mocks;
using System;

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
            calendar.DailySchedule = new DailySchedule
            {
                FajrBegins = DateTime.Parse("10:00"),
                FajrJamaat = DateTime.Parse("11:00"),

                ZuhrBegins = DateTime.Parse("12:00"),
                ZuhrJamaat = DateTime.Parse("13:00"),

                AsrBegins = DateTime.Parse("14:00"),
                AsrJamaat = DateTime.Parse("15:00"),

                MaghribBegins = DateTime.Parse("16:00"),
                MaghribJamaat = DateTime.Parse("17:00"),

                IshaBegins = DateTime.Parse("18:00"),
                IshaJamaat = DateTime.Parse("19:00"),
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
