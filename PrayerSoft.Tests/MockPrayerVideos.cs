using PrayerSoft.Data;

namespace PrayerSoft.Tests
{
    public class MockPrayerVideos: IPrayerVideos
    {
        public string Video { get; set; }

        public string Get(string prayerName)
        {
            return Video;
        }
    }
}