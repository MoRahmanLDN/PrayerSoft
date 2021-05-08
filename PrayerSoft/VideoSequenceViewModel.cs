using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class VideoSequenceViewModel: ISequenceViewModel
    {
        private readonly IFileEnumerator videoEnumerator;
        public string Video { get; set; }
        public bool HasCurrentVideoEnded { get; set; }
        public bool HasEnded { get; set; }

        public VideoSequenceViewModel(IFileEnumerator videoEnumerator)
        {
            this.videoEnumerator = videoEnumerator;
        }

        public void Refresh()
        {
            if (Video == null || HasCurrentVideoEnded)
            {
                if (videoEnumerator.IsComplete)
                {
                    HasEnded = true;
                }
                else
                {
                    Video = videoEnumerator.GetNext();
                }
            }
        }

        public void Reset()
        {
            HasEnded = false;
            videoEnumerator.Reset();
        }
    }
}