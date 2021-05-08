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
        private FileRepository imagesRepository;
        private FileRepository videosRepository;

        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }
        public SlideshowViewModel Slideshow { get; set; }
        public VideoSequenceViewModel VideoSequence { get; set; }

        public object Media { get; set; }

        public MainWindowViewModel()
        {
            clock = new Clock();
            repository = new DailyPrayerTimesRepository();
            imagesRepository = new FileRepository();
            videosRepository = new FileRepository();

            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, repository);
            Slideshow = new SlideshowViewModel(clock, imagesRepository, TimeSpan.FromSeconds(5));
            VideoSequence = new VideoSequenceViewModel(videosRepository);

            Media = VideoSequence;
        }

        public void OnLoaded()
        {
            LoadData();
            Refresh();
            SetRefreshTimer();
        }

        private void LoadData()
        {
            repository.Load(File.ReadAllText("calendar.csv"));
            imagesRepository.Load(@"Images","*.jpg");
            videosRepository.Load(@"Videos", "*.mp4");
        }

        private void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
            Slideshow.Refresh();
            VideoSequence.Refresh();
        }

        private void SetRefreshTimer()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, eventArgs) => Refresh();
            timer.Start();
        }
    }
}
