using PrayerSoft.Data;
using PropertyChanged;
using System;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class VideoSequenceViewModel
    {
        private readonly IFileRepository videoRepository;

        public VideoSequenceViewModel(IFileRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public string Video { get; set; }

        public void Play()
        {
            Video = videoRepository.GetNext();
        }

        public void OnVideoFinished()
        {
            Video = videoRepository.GetNext();
        }
    }
}