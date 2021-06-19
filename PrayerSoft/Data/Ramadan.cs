using System;

namespace PrayerSoft.Data
{
    public class Ramadan : IRamadan
    {
        public DateTime GetEndDate()
        {
            return new DateTime(2021, 5, 12);
        }

        public DateTime GetStartDate()
        {
            return new DateTime(2021, 4, 13);
        }
    }
}
