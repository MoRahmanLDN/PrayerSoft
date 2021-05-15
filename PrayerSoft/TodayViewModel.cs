﻿using PrayerSoft.Data;
using PropertyChanged;
using System;

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

        public TodayViewModel(
            IClock clock,
            ICalendar calendar,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            TimeSpan slideshowInterval,
            IMessageEnumerator messageEnumerator,
            TimeSpan messageInterval)
        {
            DateAndTime = new DateAndTimeViewModel(clock);
            DailySchedule = new DailyScheduleViewModel(clock, calendar);
            var imageSequence = new ImageSequenceViewModel(clock, imageEnumerator, slideshowInterval);
            var videoSequence = new VideoSequenceViewModel(videoEnumerator);
            AlternatingSequence = new AlternatingSequenceViewModel(imageSequence, videoSequence);
            Countdown = new CountdownViewModel(clock, calendar);
            Messages = new MessagesViewModel(clock, messageEnumerator, messageInterval);
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