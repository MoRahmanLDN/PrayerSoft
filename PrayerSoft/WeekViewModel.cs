using PrayerSoft.Data;

namespace PrayerSoft
{
    public class WeekViewModel : IViewModel
    {
        public WeeklyScheduleViewModel Schedule { get; set; }

        public WeekViewModel(IClock clock, ICalendar calendar)
        {
            Schedule = new WeeklyScheduleViewModel(clock, calendar);
        }

        public void Load()
        {
            Schedule.Load();
        }

        public void Refresh()
        {
            Schedule.Refresh();
        }
    }
}
