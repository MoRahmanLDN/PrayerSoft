using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class RamadanViewModel : IViewModel
    {
        private readonly IClock clock;
        private readonly IRamadan ramadan;
        private Format format;

        public RamadanViewModel(IClock clock, IRamadan ramadan)
        {
            this.clock = clock;
            this.ramadan = ramadan;
            this.format = new Format();
        }
        
        public string Title { get; set; }
        public string Period { get; set; }
        public string Day { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            var startDate = ramadan.GetStartDate();
            var endDate = ramadan.GetEndDate();

            Title = $"Ramadan {now.Year}";
            Period = $"{format.ShortDate(startDate)} - {format.ShortDate(endDate)}";
            Day = $"Today is day {(now - startDate).Days + 1} of Ramadan";
        }
    }
}