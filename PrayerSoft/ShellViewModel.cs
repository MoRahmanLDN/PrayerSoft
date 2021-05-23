using PrayerSoft.Data;
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

        private TodayViewModel todayViewModel;
        private PrayerJamaatViewModel prayerJamaatViewModel;
        private PrayerBeginsViewModel prayerBeginsViewModel;

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

            todayViewModel = new TodayViewModel(
                clock, 
                filesystem,                
                configuration,
                calendar);

            prayerJamaatViewModel = new PrayerJamaatViewModel(clock);
            prayerBeginsViewModel = new PrayerBeginsViewModel(new PrayerVideos());
        }

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
                Current = todayViewModel;
            }
            Current.Refresh();
        }

        public void Load()
        {
            configuration.Load();
            calendar.Load();
            todayViewModel.Load();
        }
    }
}
