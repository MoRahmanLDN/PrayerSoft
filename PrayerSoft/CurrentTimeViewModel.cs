namespace PrayerSoft
{
    public class CurrentTimeViewModel
    {
        public CurrentTimeViewModel(IClock clock)
        {
        }

        public string CurrentTime { get; set; }

        public void Refresh()
        {
        }
    }
}
