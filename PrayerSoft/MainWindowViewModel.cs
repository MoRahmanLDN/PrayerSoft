using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.IO;
using System.Windows.Threading;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel: IViewModel
    {
        private Clock clock;
        private DailyPrayerTimesRepository repository;
        private FileEnumerator imagesRepository;
        private FileEnumerator videosRepository;

        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }
        public SlideshowViewModel Slideshow { get; set; }
        public VideoSequenceViewModel VideoSequence { get; set; }

        public IViewModel Media { get; set; }

        public MainWindowViewModel()
        {
            clock = new Clock();
            repository = new DailyPrayerTimesRepository();
            imagesRepository = new FileEnumerator();
            videosRepository = new FileEnumerator();

            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, repository);
            Slideshow = new SlideshowViewModel(clock, imagesRepository, TimeSpan.FromSeconds(5));
            VideoSequence = new VideoSequenceViewModel(videosRepository);

            Media = Slideshow;
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

        public void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
            Media.Refresh();
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
