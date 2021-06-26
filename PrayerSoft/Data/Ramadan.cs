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

        public DateTime GetSuhurEnds(DateTime now)
        {
            throw new NotImplementedException();
        }

        public DateTime GetIftarBegins(DateTime now)
        {
            throw new NotImplementedException();
        }

        public DateTime GetFirstTaraweeh(DateTime now)
        {
            throw new NotImplementedException();
        }

        public DateTime GetSecondTaraweeh(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
