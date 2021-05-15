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
            IConfiguration configuration,
            ICalendar calendar,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            IMessageEnumerator messageEnumerator)
        {
            Current = new TodayViewModel(
                clock, 
                configuration,
                calendar, 
                imageEnumerator, 
                videoEnumerator, 
                messageEnumerator);
        }

        public void Refresh()
        {
            Current.Refresh();
        }
    }
}
