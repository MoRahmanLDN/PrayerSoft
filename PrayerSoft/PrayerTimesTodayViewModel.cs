using System;

namespace PrayerSoft.Tests
{
    public class PrayerTimesTodayViewModel
    {
        private IClock clock;
        private IPrayerTimesRepository repository;
        private Format format;

        public PrayerTimesTodayViewModel(IClock clock, IPrayerTimesRepository repository)
        {
            this.clock = clock;
            this.repository = repository;
            format = new Format();
        }

        public string FajrBegins { get; set; }
        public string FajrJamaat { get; set; }

        public string AsrBegins { get; set; }
        public string AsrJamaat { get; set; }

        public string MaghribBegins { get; set; }
        public string MaghribJamaat { get; set; }

        public string IshaBegins { get; set; }
        public string IshaJamaat { get; set; }

        public void Refresh()
        {
            DateTime today = clock.Read();
            var prayerTimes = repository.Get(today);
            
            FajrBegins = format.ShortTime(prayerTimes.FajrBegins);
            FajrJamaat = format.ShortTime(prayerTimes.FajrJamaat);

            AsrBegins = format.ShortTime(prayerTimes.AsrBegins);
            AsrJamaat = format.ShortTime(prayerTimes.AsrJamaat);

            MaghribBegins = format.ShortTime(prayerTimes.MaghribBegins);
            MaghribJamaat = format.ShortTime(prayerTimes.MaghribJamaat);

            IshaBegins = format.ShortTime(prayerTimes.IshaBegins);
            IshaJamaat = format.ShortTime(prayerTimes.IshaJamaat);
        }
    }
}