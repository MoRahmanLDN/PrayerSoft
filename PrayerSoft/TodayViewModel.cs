using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class TodayViewModel : IViewModel
    {
        public MosqueViewModel Mosque { get; set; }
        public DateAndTimeViewModel DateAndTime { get; set; }
        public DailyScheduleViewModel DailySchedule { get; set; }
        public AlternatingSequenceViewModel AlternatingSequence { get; set; }
        public CountdownViewModel Countdown { get; set; }
        public MessagesViewModel Messages { get; set; }
        public RamadanViewModel Ramadan { get; set; }

        private ImageEnumerator imageEnumerator;
        private VideoEnumerator videoEnumerator;
        private MessageEnumerator messageEnumerator;

        public TodayViewModel(
            IClock clock,
            IFilesystem filesystem,
            IConfiguration configuration,
            ICalendar calendar, 
            IRamadan ramadan)
        {
            Mosque = new MosqueViewModel(configuration);
            DateAndTime = new DateAndTimeViewModel(clock, configuration);
            DailySchedule = new DailyScheduleViewModel(clock, calendar);

            imageEnumerator = new ImageEnumerator(filesystem, configuration);
            videoEnumerator = new VideoEnumerator(filesystem, configuration);
            messageEnumerator = new MessageEnumerator(filesystem, configuration);

            var imageSequence = new ImageSequenceViewModel(clock, configuration, imageEnumerator);
            var videoSequence = new VideoSequenceViewModel(videoEnumerator);
            AlternatingSequence = new AlternatingSequenceViewModel(imageSequence, videoSequence);
            Countdown = new CountdownViewModel(clock, calendar);
            Messages = new MessagesViewModel(clock, configuration, messageEnumerator);
            Ramadan = new RamadanViewModel(clock, ramadan, configuration);
        }

        public void Load()
        {   
            imageEnumerator.Load();
            videoEnumerator.Load();
            messageEnumerator.Load();
        }

        public void Refresh()
        {
            Mosque.Refresh();
            DateAndTime.Refresh();
            DailySchedule.Refresh();
            AlternatingSequence.Refresh();
            Countdown.Refresh();
            Messages.Refresh();
            Ramadan.Refresh();
        }
    }
}
