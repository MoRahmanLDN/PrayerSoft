using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class RamadanViewModel : IViewModel
    {
        private readonly IClock clock;

        public RamadanViewModel(IClock clock)
        {
            this.clock = clock;
        }

        public string Title { get; set; }

        public void Refresh()
        {
            var year = clock.Read().Year;
            Title = $"Ramadan {year}";
        }
    }
}