using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class ImageSequenceViewModel: ISequenceViewModel
    {
        private readonly IClock clock;
        private readonly IFileEnumerator imageEnumerator;
        private readonly IConfiguration configuration;
        private DateTime? lastUpdate;

        public string Image { get; set; }
        public bool HasEnded { get; set; }

        public ImageSequenceViewModel(IClock clock, IConfiguration configuration, IFileEnumerator imageEnumerator)
        {
            this.clock = clock;
            this.configuration = configuration;
            this.imageEnumerator = imageEnumerator;
        }

        public void Refresh()
        {
            var now = clock.Read();
            var interval = configuration.GetImagesInterval();

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