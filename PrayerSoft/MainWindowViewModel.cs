using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel: IViewModel
    {
        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }
        public SlideshowViewModel Slideshow { get; set; }
        public VideoSequenceViewModel VideoSequence { get; set; }

        public ISequenceViewModel Media { get; set; }

        private LayoutEngine layoutEngine { get; set; }

        public MainWindowViewModel(
            IClock clock,
            IPrayerTimesRepository prayerTimesRepository,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            TimeSpan slideshowInterval)
        {
            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, prayerTimesRepository);
            Slideshow = new SlideshowViewModel(clock, imageEnumerator, slideshowInterval);
            VideoSequence = new VideoSequenceViewModel(videoEnumerator);

            layoutEngine = new LayoutEngine(Slideshow, VideoSequence);
        }

        public void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
            Media = layoutEngine.Choose();
            Media.Refresh();
        }
    }
}
