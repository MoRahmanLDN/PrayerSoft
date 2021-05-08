using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class VideoSequenceViewModel
    {
        private readonly IFileRepository videoRepository;
        public string Video { get; set; }
        public bool HasEnded { get; set; }

        public VideoSequenceViewModel(IFileRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public void Refresh()
        {
            if (Video == null || HasEnded)
            {
                Video = videoRepository.GetNext();
            }
        }
    }
}