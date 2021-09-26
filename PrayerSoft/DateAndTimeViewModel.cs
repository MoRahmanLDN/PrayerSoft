using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class DateAndTimeViewModel: IViewModel
    {
        readonly IConfiguration configuration;
        readonly IClock clock;
        readonly Format format;

        public DateAndTimeViewModel(IClock clock, IConfiguration configuration)
        {
            this.clock = clock;
            this.configuration = configuration;
            format = new Format();
        }

        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentIslamicDate { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            CurrentTime = format.LongTime(now);
            CurrentDate = format.LongDate(now);
            CurrentIslamicDate = format.IslamicDate(now, configuration.GetHijriAdjustment());
        }
    }
}
