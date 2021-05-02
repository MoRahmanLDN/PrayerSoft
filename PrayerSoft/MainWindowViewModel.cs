using PrayerSoft.Data;
using System;
using System.IO;
using System.Windows.Threading;

namespace PrayerSoft
{
    public class MainWindowViewModel
    {
        private Clock clock;
        private DailyPrayerTimesRepository repository;
        private ImagesRepository imagesRepository;

        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }
        public SlideshowViewModel Slideshow { get; set; }

        public MainWindowViewModel()
        {
            clock = new Clock();
            repository = new DailyPrayerTimesRepository();
            imagesRepository = new ImagesRepository();

            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, repository);
            Slideshow = new SlideshowViewModel(clock, imagesRepository, TimeSpan.FromSeconds(5));
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
            imagesRepository.Load(@"Images","*.jpg");
        }

        private void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
            Slideshow.Refresh();
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
