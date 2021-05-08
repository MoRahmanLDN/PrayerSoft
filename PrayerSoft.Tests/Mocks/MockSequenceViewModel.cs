namespace PrayerSoft.Tests.Mocks
{
    public class MockSequenceViewModel : ISequenceViewModel
    {
        public bool HasEnded { get; set; }

        public bool IsRefreshed { get; set; }

        public bool IsReset { get; set; }

        public void Refresh()
        {
            IsRefreshed = true;
        }

        public void Reset()
        {
            IsReset = true;
        }
    }
}
