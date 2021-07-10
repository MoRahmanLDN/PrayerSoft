using PrayerSoft.Data;

namespace PrayerSoft
{
    public class WeekViewModel : IViewModel
    {
        public WeeklyScheduleViewModel Schedule { get; set; }
        public MessagesViewModel Messages { get; set; }

        private MessageEnumerator messageEnumerator;

        public WeekViewModel(
            IClock clock, 
            IFilesystem filesyste, 
            IConfiguration configuration, 
            ICalendar calendar)
        {
            Schedule = new WeeklyScheduleViewModel(clock, calendar);

            messageEnumerator = new MessageEnumerator(filesyste, configuration);
            Messages = new MessagesViewModel(clock, configuration, messageEnumerator);
        }

        public void Load()
        {
            messageEnumerator.Load();
            Schedule.Load();
        }

        public void Refresh()
        {
            Schedule.Refresh();
            Messages.Refresh();
        }
    }
}
