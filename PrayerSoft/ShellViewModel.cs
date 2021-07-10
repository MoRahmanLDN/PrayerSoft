using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;
        private readonly ICalendar calendar;
        private readonly IRamadan ramadan;

        private TodayViewModel todayViewModel;
        private WeekViewModel weekViewModel;
        private PrayerJamaatViewModel prayerJamaatViewModel;
        private PrayerBeginsViewModel prayerBeginsViewModel;

        public IViewModel Current { get; set; }

        public ShellViewModel(
            IClock clock, 
            IFilesystem filesystem,
            IConfiguration configuration,
            ICalendar calendar,
            IRamadan ramadan)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.calendar = calendar;
            this.ramadan = ramadan;

            todayViewModel = new TodayViewModel(
                clock, 
                filesystem,                
                configuration,
                calendar,
                ramadan);

            weekViewModel = new WeekViewModel(clock, calendar);

            prayerJamaatViewModel = new PrayerJamaatViewModel(clock);
            prayerBeginsViewModel = new PrayerBeginsViewModel(new PrayerVideos());
        }

        private DateTime? lastSwitch;

        public void Refresh()
        {
            var now = clock.Read();
            var prayers = calendar.GetPrayers(now);
            var interval = configuration.GetPrayerJamaatInterval();
            var prayersJamaat = prayers.Where(p => p.Jamaat < now && now < p.Jamaat + interval);
            var prayersBegins = prayers.Where(p => p.Begins < now && now < p.Jamaat);

            if (prayersJamaat.Any())
            {
                var prayerJamaat = prayersJamaat.Single();
                prayerJamaatViewModel.PrayerName = prayerJamaat.Name;
                Current = prayerJamaatViewModel;
            }
            else if (prayersBegins.Any() && !prayerBeginsViewModel.HasEnded)
            {
                var prayerBegins = prayersBegins.Single();
                prayerBeginsViewModel.PrayerName = prayerBegins.Name;
                Current = prayerBeginsViewModel;
            }
            else
            {
                if (Current == null || Current is PrayerBeginsViewModel || Current is PrayerJamaatViewModel)
                {
                    Current = todayViewModel;
                    lastSwitch = now;
                }
                else if (Current is TodayViewModel && now >= lastSwitch + configuration.GetTodayTimetableInterval())
                {
                    Current = weekViewModel;
                    lastSwitch = now;
                }
                else if (Current is WeekViewModel && now >= lastSwitch + configuration.GetWeeklyTimetableInterval())
                {
                    Current = todayViewModel;
                    lastSwitch = now;
                }
            }
            Current.Refresh();
        }

        public void Load()
        {
            configuration.Load();
            calendar.Load();
            ramadan.Load();
            todayViewModel.Load();
            weekViewModel.Load();
        }
    }
}
