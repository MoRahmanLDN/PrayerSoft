using PrayerSoft.Data;
using PropertyChanged;

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
        public string SuhurEnds { get; set; }
        public string IftarBegins { get; set; }
        public string FirstTaraweeh { get; set; }
        public string SecondTaraweeh { get; set; }

        public void Refresh()
        {
            var now = clock.Read();
            var startDate = ramadan.GetStartDate();
            var endDate = ramadan.GetEndDate();

            Title = $"Ramadan {now.Year}";
            Period = $"{format.ShortDate(startDate)} - {format.ShortDate(endDate)}";
            Day = $"Today is day {(now - startDate).Days + 1} of Ramadan";

            SuhurEnds = format.ShortTime(ramadan.GetSuhurEnds(now));
            IftarBegins = format.ShortTime(ramadan.GetIftarBegins(now));
            FirstTaraweeh = format.ShortTime(ramadan.GetFirstTaraweeh(now));
            SecondTaraweeh = format.ShortTime(ramadan.GetSecondTaraweeh(now));
        }
    }
}