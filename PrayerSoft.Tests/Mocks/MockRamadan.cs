using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockRamadan : IRamadan
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SuhurEnds { get; set; }
        public DateTime IftarBegins { get; set; }
        public DateTime FirstTaraweeh { get; internal set; }
        public DateTime SecondTaraweeh { get; internal set; }

        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public DateTime GetStartDate()
        {
            return StartDate;
        }

        public DateTime GetSuhurEnds(DateTime now)
        {
            return SuhurEnds;
        }

        public DateTime GetIftarBegins(DateTime now)
        {
            return IftarBegins;
        }

        public DateTime GetFirstTaraweeh(DateTime now)
        {
            return FirstTaraweeh;
        }

        public DateTime GetSecondTaraweeh(DateTime now)
        {
            return SecondTaraweeh;
        }

        public void Load()
        {
        }
    }
}
