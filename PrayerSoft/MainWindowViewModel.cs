using System;
using System.IO;
using System.Windows.Threading;

namespace PrayerSoft
{
    public class MainWindowViewModel
    {
        private Clock clock;
        private DailyPrayerTimesRepository repository;

        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }

        public MainWindowViewModel()
        {
            clock = new Clock();
            repository = new DailyPrayerTimesRepository();
            
            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, repository);
        }

        public void OnLoaded()
        {
            LoadCalendar();
            Refresh();
            SetTimer();
        }

        private void LoadCalendar()
        {
            repository.Load(File.ReadAllText("calendar.csv"));
        }

        private void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
        }

        private void SetTimer()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, eventArgs) => Refresh();
            timer.Start();
        }
    }
}
