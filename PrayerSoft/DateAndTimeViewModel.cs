using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class DateAndTimeViewModel: IViewModel
    {
        readonly IClock clock;
        readonly Format format;

        public DateAndTimeViewModel(IClock clock)
        {
            this.clock = clock;
            format = new Format();
        }

        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentIslamicDate { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            CurrentTime = format.LongTime(now);
            CurrentDate = format.Date(now);
            CurrentIslamicDate = format.IslamicDate(now);
        }
    }
}
