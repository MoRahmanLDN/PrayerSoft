using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class SlideshowViewModel
    {
        private readonly IClock clock;
        private readonly IFileRepository imagesRepository;
        private readonly TimeSpan interval;
        private DateTime? lastUpdate;

        public string Image { get; set; }
        
        public SlideshowViewModel(IClock clock, IFileRepository imagesRepository, TimeSpan interval)
        {
            this.clock = clock;
            this.imagesRepository = imagesRepository;
            this.interval = interval;
        }

        public void Refresh()
        {
            var now = clock.Read();
            if (lastUpdate == null || now >= lastUpdate + interval)
            {
                Image = imagesRepository.GetNext();
                lastUpdate = now;
            }
        }
    }
}