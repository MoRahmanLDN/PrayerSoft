﻿using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class TodayViewModel : IViewModel
    {
        public DateAndTimeViewModel DateAndTime { get; set; }
        public DailyScheduleViewModel DailySchedule { get; set; }
        public AlternatingSequenceViewModel AlternatingSequence { get; set; }
        public CountdownViewModel Countdown { get; set; }
        public MessagesViewModel Messages { get; set; }

        private ImageEnumerator imageEnumerator;
        private VideoEnumerator videoEnumerator;
        private MessageEnumerator messageEnumerator;

        public TodayViewModel(
            IClock clock,
            IFilesystem filesystem,
            IConfiguration configuration,
            ICalendar calendar)
        {
            DateAndTime = new DateAndTimeViewModel(clock);
            DailySchedule = new DailyScheduleViewModel(clock, calendar);

            imageEnumerator = new ImageEnumerator(filesystem, configuration);
            videoEnumerator = new VideoEnumerator(filesystem, configuration);
            messageEnumerator = new MessageEnumerator(filesystem, configuration);

            var imageSequence = new ImageSequenceViewModel(clock, configuration, imageEnumerator);
            var videoSequence = new VideoSequenceViewModel(videoEnumerator);
            AlternatingSequence = new AlternatingSequenceViewModel(imageSequence, videoSequence);
            Countdown = new CountdownViewModel(clock, calendar);
            Messages = new MessagesViewModel(clock, configuration, messageEnumerator);
        }

        public void Load()
        {
            imageEnumerator.Load();
            videoEnumerator.Load();
            messageEnumerator.Load();
        }

        public void Refresh()
        {
            DateAndTime.Refresh();
            DailySchedule.Refresh();
            AlternatingSequence.Refresh();
            Countdown.Refresh();
            Messages.Refresh();
        }
    }
}
