using System;
using System.Globalization;

namespace PrayerSoft
{
    public class Format
    {
        public string LongTime(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        public string LongTime(TimeSpan timeSpan)
        {
            return timeSpan.ToString("hh':'mm':'ss");
        }

        public string ShortTime(DateTime date)
        {
            return date.ToString("HH:mm");
        }

        public string LongDate(DateTime date)
        {
            return date.ToString("ddddd, dd MMMM yyyy");
        }

        public string ShortDate(DateTime date)
        {
            return date.ToString("ddddd, dd MMMM");
        }

        private static string[] IslamicMonths = new string[]
        {
            "Moharram",
            "Safar",
            "Rabi-al-Awwal",
            "Rabi-us-saani",
            "jumad-al-ula",
            "jumad-al-akhir",
            "Rajab",
            "Sha'ban",
            "Ramadan",
            "Shawwal",
            "zul Aqad'ah",
            "zul Hijjah",
            ""
        };

        public string IslamicDate(DateTime date, int hijriAdjustment)
        {
            var format = CultureInfo.CreateSpecificCulture("ar").DateTimeFormat;
            format.Calendar = new HijriCalendar { HijriAdjustment = hijriAdjustment };
            format.MonthGenitiveNames = IslamicMonths;
            return date.ToString("dd MMMM yyyy", format);
        }
    }
}
