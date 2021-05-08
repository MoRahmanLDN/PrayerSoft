using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class VideoSequenceViewModel: IViewModel
    {
        private readonly IFileEnumerator videoEnumerator;
        public string Video { get; set; }
        public bool HasCurrentVideoEnded { get; set; }
        public bool HasEnded => videoEnumerator.IsComplete && HasCurrentVideoEnded;

        public VideoSequenceViewModel(IFileEnumerator videoEnumerator)
        {
            this.videoEnumerator = videoEnumerator;
        }

        public void Refresh()
        {
            if (Video == null || HasCurrentVideoEnded)
            {
                Video = videoEnumerator.GetNext();
            }
        }

        public void Reset()
        {
            videoEnumerator.Reset();
        }
    }
}