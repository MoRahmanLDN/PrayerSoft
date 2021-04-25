namespace PrayerSoft.Tests
{
    internal class MockClock: IClock
    {
        string time;
        string date;
        string islamicDate;

        public MockClock()
        {
        }

        public string GetTime()
        {
            return time;
        }

        public void SetTime(string time)
        {
            this.time = time;
        }

        public string GetDate()
        {
            return date;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }

        public string GetIslamicDate()
        {
            return islamicDate;
        }

        public void SetIslamicDate(string islamicDate)
        {
            this.islamicDate = islamicDate;
        }
    }
}