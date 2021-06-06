using System.Collections.Generic;

namespace PrayerSoft
{
    public class PrayersPerDayViewModel
    {
        public string DayOfWeek { get; set; }
        public List<PrayerViewModel> Prayers { get; set; }
    }
}
