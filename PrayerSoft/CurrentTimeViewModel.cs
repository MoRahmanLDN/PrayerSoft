using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class CurrentTimeViewModel
    {
        readonly IClock clock;

        public CurrentTimeViewModel(IClock clock)
        {
            this.clock = clock;
        }

        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }

        public void Refresh()
        {
            CurrentTime = clock.GetTime();
            CurrentDate = clock.GetDate();
        }
    }
}
