using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;
        private readonly Calendar calendar;
        private readonly ImageEnumerator imageEnumerator;
        private readonly VideoEnumerator videoEnumerator;
        private readonly MessageEnumerator messageEnumerator;

        public IViewModel Current { get; set; }

        public ShellViewModel() : this(
            new Clock(),
            new Filesystem(),
            new Configuration())
        {
        }

        public ShellViewModel(
            IClock clock, 
            IFilesystem filesystem, 
            IConfiguration configuration) : this(
                clock,
                configuration,
                new Calendar(filesystem, configuration),
                new ImageEnumerator(filesystem, configuration),
                new VideoEnumerator(filesystem, configuration),
                new MessageEnumerator(filesystem, configuration))
        {
        }

        public ShellViewModel(
            IClock clock, 
            IConfiguration configuration,
            ICalendar calendar,
            IFileEnumerator imageEnumerator,
            IFileEnumerator videoEnumerator,
            IMessageEnumerator messageEnumerator)
        {
            this.clock = clock;
            this.configuration = configuration;

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

        public void Load()
        {
            configuration.Load();
            calendar.Load();
            imageEnumerator.Load();
            videoEnumerator.Load();
            messageEnumerator.Load();
        }
    }
}
