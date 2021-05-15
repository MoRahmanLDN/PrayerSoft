using PrayerSoft.Data;
using PrayerSoft.Utilities;
using PropertyChanged;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;
        private readonly ICalendar calendar;

        private TodayViewModel today;
        private PrayerJamaatViewModel prayerJamaat;

        public IViewModel Current { get; set; }

        public ShellViewModel(
            IClock clock, 
            IFilesystem filesystem,
            IConfiguration configuration,
            ICalendar calendar)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.calendar = calendar;

            today = new TodayViewModel(
                clock, 
                filesystem,                
                configuration,
                calendar);

            prayerJamaat = new PrayerJamaatViewModel();
        }

        public void Refresh()
        {
            if (IsPrayerJamaatTime())
            {
                Current = prayerJamaat;
            }
            else
            {
                Current = today;
            }
            Current.Refresh();
        }

        private bool IsPrayerJamaatTime()
        {
            var now = clock.Read();
            var schedule = calendar.Get(now);
            var interval = configuration.GetPrayerJamaatInterval();
            var jamaatIntervals = schedule.JamaatTimes.Select(t => new Range(t, t + interval));
            return jamaatIntervals.Any(i => i.Contains(now));
        }

        public void Load()
        {
            configuration.Load();
            calendar.Load();
            today.Load();
        }
    }
}
