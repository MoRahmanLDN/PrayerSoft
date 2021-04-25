namespace PrayerSoft
{
    public class CurrentTimeViewModel
    {
        IClock clock;

        public CurrentTimeViewModel(IClock clock)
        {
            this.clock = clock;
        }

        public string CurrentTime { 
            get
            {
                return clock.GetTime();
            }
        }

        public void Refresh()
        {
        }
    }
}
