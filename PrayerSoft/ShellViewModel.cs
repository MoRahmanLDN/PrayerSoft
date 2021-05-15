using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {
        public IViewModel Current { get; set; }

        public ShellViewModel(
            IClock clock,
            ICalendar calendar,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            TimeSpan slideshowInterval,
            IMessageEnumerator messageEnumerator,
            TimeSpan messageInterval)
        {
            Current = new TodayViewModel(
                clock, 
                calendar, 
                imageEnumerator, 
                videoEnumerator, 
                slideshowInterval, 
                messageEnumerator, 
                messageInterval);
        }

        public void Refresh()
        {
            Current.Refresh();
        }
    }
}
