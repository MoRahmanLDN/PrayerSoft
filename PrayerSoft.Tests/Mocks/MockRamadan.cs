using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests.Mocks
{
    public class MockRamadan : IRamadan
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public DateTime GetStartDate()
        {
            return StartDate;
        }
    }
}
