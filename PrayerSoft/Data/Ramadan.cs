using System;

namespace PrayerSoft.Data
{
    public class Ramadan : IRamadan
    {
        public DateTime GetStartDate()
        {
            return new DateTime(2021, 6, 1);
        }

        public DateTime GetEndDate()
        {
            return new DateTime(2021, 8, 1);
        }
    }
}
