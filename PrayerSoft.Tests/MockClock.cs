using System;

namespace PrayerSoft.Tests
{
    internal class MockClock: IClock
    {
        DateTime dateTime;

        public MockClock()
        {
        }

        public DateTime Read()
        {
            return dateTime;
        }

        public void Set(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
    }
}