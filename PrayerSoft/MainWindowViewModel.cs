using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : IViewModel
    {
        public CurrentTimeViewModel Today { get; set; }
        public PrayerTimesTodayViewModel PrayersToday { get; set; }
        public AlternatingSequenceViewModel AlternatingSequence { get; set; }
        
        public MainWindowViewModel(
            IClock clock,
            IPrayerTimesRepository prayerTimesRepository,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            TimeSpan slideshowInterval)
        {
            Today = new CurrentTimeViewModel(clock);
            PrayersToday = new PrayerTimesTodayViewModel(clock, prayerTimesRepository);
            var imageSequence = new ImageSequenceViewModel(clock, imageEnumerator, slideshowInterval);
            var videoSequence = new VideoSequenceViewModel(videoEnumerator);
            AlternatingSequence = new AlternatingSequenceViewModel(imageSequence, videoSequence);
        }

        public void Refresh()
        {
            Today.Refresh();
            PrayersToday.Refresh();
            AlternatingSequence.Refresh();
        }
    }
}
