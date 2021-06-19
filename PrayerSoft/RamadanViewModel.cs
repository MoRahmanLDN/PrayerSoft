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

        public void Refresh()
        {
            SetTitle();
            SetPeriod();
        }

        private void SetTitle()
        {
            var year = clock.Read().Year;
            Title = $"Ramadan {year}";
        }

        private void SetPeriod()
        {
            string startDate = format.ShortDate(ramadan.GetStartDate());
            string endDate = format.ShortDate(ramadan.GetEndDate());
            Period = $"{startDate} - {endDate}";
        }
    }
}