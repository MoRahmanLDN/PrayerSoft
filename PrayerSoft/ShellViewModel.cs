using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {   
        private Configuration configuration;
        private Calendar calendar;
        private ImageEnumerator imageEnumerator;
        private VideoEnumerator videoEnumerator;
        private MessageEnumerator messageEnumerator;

        public IViewModel Current { get; set; }

        public ShellViewModel(IClock clock, IFilesystem filesystem)
        {
            configuration = new Configuration();
            calendar = new Calendar(filesystem, configuration);
            imageEnumerator = new ImageEnumerator(filesystem, configuration);
            videoEnumerator = new VideoEnumerator(filesystem, configuration);
            messageEnumerator = new MessageEnumerator(filesystem, configuration);

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
            calendar.Load();
            imageEnumerator.Load();
            videoEnumerator.Load();
            messageEnumerator.Load();
        }
    }
}
