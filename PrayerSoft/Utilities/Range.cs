using System;

namespace PrayerSoft.Utilities
{
    public class Range
    {
        private readonly DateTime start;
        private readonly DateTime end;

        public Range(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Contains(DateTime date)
        {
            return start <= date && date <= end;
        }
    }
}
