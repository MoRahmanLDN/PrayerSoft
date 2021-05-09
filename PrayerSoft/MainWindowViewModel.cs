using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : IViewModel
    {
        public DateAndTimeViewModel DateAndTime { get; set; }
        public DailyScheduleViewModel DailySchedule { get; set; }
        public AlternatingSequenceViewModel AlternatingSequence { get; set; }
        
        public MainWindowViewModel(
            IClock clock,
            ICalendar prayerTimesRepository,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            TimeSpan slideshowInterval)
        {
            DateAndTime = new DateAndTimeViewModel(clock);
            DailySchedule = new DailyScheduleViewModel(clock, prayerTimesRepository);
            var imageSequence = new ImageSequenceViewModel(clock, imageEnumerator, slideshowInterval);
            var videoSequence = new VideoSequenceViewModel(videoEnumerator);
            AlternatingSequence = new AlternatingSequenceViewModel(imageSequence, videoSequence);
        }

        public void Refresh()
        {
            DateAndTime.Refresh();
            DailySchedule.Refresh();
            AlternatingSequence.Refresh();
        }
    }
}
