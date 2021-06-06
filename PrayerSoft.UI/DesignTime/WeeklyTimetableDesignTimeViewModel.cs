using System.Collections.Generic;

namespace PrayerSoft.UI.DesignTime
{
    class WeeklyTimetableDesignTimeViewModel
    {
        private static List<PrayerViewModel> prayers = new List<PrayerViewModel>
        {
            new PrayerViewModel
            {
                PrayerName = "Fajr",
                Begins = "10:10",
                Jamaat = "11:11"
            },
            new PrayerViewModel
            {
                PrayerName = "Zuhr",
                Begins = "12:12",
                Jamaat = "13:13",
                IsNext = true
            },
            new PrayerViewModel
            {
                PrayerName = "Asr",
                Begins = "14:14",
                Jamaat = "15:15"
            },
            new PrayerViewModel
            {
                PrayerName = "Maghrib",
                Begins = "16:16",
                Jamaat = "17:17"
            },
            new PrayerViewModel
            {
                PrayerName = "Isha",
                Begins = "18:18",
                Jamaat = "19:19"
            }
        };

        public List<PrayersPerDayViewModel> WeeklyPrayers { get; set; } = new List<PrayersPerDayViewModel>
        {
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Monday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Tuesday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Wednesday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Thursday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Friday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Saturday",
                Prayers = prayers
            },
            new PrayersPerDayViewModel
            {
                DayOfWeek = "Sunday",
                Prayers = prayers
            }
        };
    }
}
