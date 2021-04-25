namespace PrayerSoft.Tests
{
    internal class MockClock: IClock
    {
        string time;
        string date;

        public MockClock()
        {
        }

        public string GetDate()
        {
            return date;
        }

        public string GetTime()
        {
            return time;
        }

        public void SetTime(string time)
        {
            this.time = time;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }
    }
}