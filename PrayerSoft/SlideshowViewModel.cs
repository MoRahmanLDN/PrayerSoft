using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class SlideshowViewModel: ISequenceViewModel
    {
        private readonly IClock clock;
        private readonly IFileEnumerator imageEnumerator;
        private readonly TimeSpan interval;
        private DateTime? lastUpdate;

        public string Image { get; set; }
        public bool HasEnded { get; set; }

        public SlideshowViewModel(IClock clock, IFileEnumerator imageEnumerator, TimeSpan interval)
        {
            this.clock = clock;
            this.imageEnumerator = imageEnumerator;
            this.interval = interval;
        }

        public void Refresh()
        {
            var now = clock.Read();
            if (lastUpdate == null || now >= lastUpdate + interval)
            {
                if (imageEnumerator.IsComplete)
                {
                    HasEnded = true;
                }
                else
                {
                    Image = imageEnumerator.GetNext();
                    lastUpdate = now;
                }
            }
        }

        public void Reset()
        {
            HasEnded = false;
            imageEnumerator.Reset();
        }
    }
}