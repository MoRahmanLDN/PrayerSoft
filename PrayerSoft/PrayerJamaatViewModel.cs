using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class PrayerJamaatViewModel : IViewModel
    {
        private readonly IClock clock;
        private Format format;

        public string PrayerName { get; set; }
        public string CurrentTime { get; set; }

        public string Message => $"{PrayerName} prayer has begun";

        public PrayerJamaatViewModel(IClock clock)
        {
            this.clock = clock;
            this.format = new Format();
        }

        public void Refresh()
        {
            var now = clock.Read();
            CurrentTime = format.LongTime(now);
        }
    }
}