namespace PrayerSoft
{
    public class CurrentTimeViewModel
    {
        IClock clock;

        public CurrentTimeViewModel(IClock clock)
        {
            this.clock = clock;
        }

        public string CurrentTime { get; set; }

        public void Refresh()
        {
            this.CurrentTime = this.clock.GetTime();
        }
    }
}
