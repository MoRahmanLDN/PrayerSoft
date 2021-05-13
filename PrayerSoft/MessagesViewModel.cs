using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MessagesViewModel: IViewModel
    {
        private readonly IClock clock;
        private readonly IMessageEnumerator messageEnumerator;
        private readonly TimeSpan interval;
        private DateTime? lastUpdate;

        public MessagesViewModel(IClock clock, IMessageEnumerator messageEnumerator, TimeSpan interval)
        {
            this.clock = clock;
            this.messageEnumerator = messageEnumerator;
            this.interval = interval;
        }

        public string Current { get; set; }
        public bool IsVisible { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            if (lastUpdate == null || now - lastUpdate > interval)
            {
                Current = messageEnumerator.GetNext(now);
                IsVisible = Current != null;
                lastUpdate = now;
            }
        }
    }
}