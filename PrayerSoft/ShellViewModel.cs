using PrayerSoft.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ShellViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;
        private readonly ICalendar calendar;

        private TodayViewModel today;
        private PrayerJamaatViewModel prayerJamaat;

        public IViewModel Current { get; set; }

        public ShellViewModel(
            IClock clock, 
            IFilesystem filesystem,
            IConfiguration configuration,
            ICalendar calendar)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.calendar = calendar;

            today = new TodayViewModel(
                clock, 
                filesystem,                
                configuration,
                calendar);

            prayerJamaat = new PrayerJamaatViewModel();
        }

        public void Refresh()
        {
            var now = clock.Read();
            var schedule = calendar.Get(now);
            var interval = configuration.GetPrayerJamaatInterval();

            var jamaatTimes = new List<DateTime> 
            {
                schedule.FajrJamaat, 
                schedule.AsrJamaat,
                schedule.ZuhrJamaat,
                schedule.MaghribJamaat,
                schedule.IshaJamaat
            };

            if (jamaatTimes.Any(t => now > t && now < t + interval))
            {
                Current = prayerJamaat;
            }
            else
            {
                Current = today;
            }
            
            Current.Refresh();
        }

        public void Load()
        {
            configuration.Load();
            calendar.Load();
            today.Load();
        }
    }
}
