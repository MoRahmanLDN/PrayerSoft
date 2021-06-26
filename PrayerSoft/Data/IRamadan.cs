using System;

namespace PrayerSoft.Data
{
    public interface IRamadan
    {
        void Load();
        DateTime GetStartDate();
        DateTime GetEndDate();
        DateTime GetSuhurEnds(DateTime now);
        DateTime GetIftarBegins(DateTime now);
        DateTime GetFirstTaraweeh(DateTime now);
        DateTime GetSecondTaraweeh(DateTime now);
    }
}