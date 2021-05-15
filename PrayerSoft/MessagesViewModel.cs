using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class MessagesViewModel: IViewModel
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;
        private readonly IMessageEnumerator messageEnumerator;
        private DateTime? lastUpdate;

        public MessagesViewModel(IClock clock, IConfiguration configuration, IMessageEnumerator messageEnumerator)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.messageEnumerator = messageEnumerator;
        }

        public string Current { get; set; }
        public bool IsVisible { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            var interval = configuration.GetMessagesInterval();

            if (lastUpdate == null || now - lastUpdate > interval)
            {
                Current = messageEnumerator.GetNext(now);
                IsVisible = Current != null;
                lastUpdate = now;
            }
        }
    }
}