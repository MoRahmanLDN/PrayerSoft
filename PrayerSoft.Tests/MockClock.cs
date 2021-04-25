namespace PrayerSoft.Tests
{
    internal class MockClock: IClock
    {
        string time;

        public MockClock()
        {
        }

        public string GetTime()
        {
            return time;
        }

        public void SetTime(string expectedTime)
        {
            time = expectedTime;
        }
    }
}