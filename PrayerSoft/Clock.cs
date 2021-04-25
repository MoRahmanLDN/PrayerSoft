using System;
using System.Globalization;

namespace PrayerSoft
{
    public class Clock : IClock
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public string GetDate()
        {
            return DateTime.Now.ToString("ddddd, dd MMM yyyy");
        }

        static string[] IslamicMonths = new string[]
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
        
        public string GetIslamicDate()
        {
            var format = CultureInfo.CreateSpecificCulture("ar").DateTimeFormat;
            format.Calendar = new HijriCalendar { HijriAdjustment = -1 };
            format.MonthGenitiveNames = IslamicMonths;
            return DateTime.Now.ToString("dd MMMM yyyy", format);
        }
    }
}
