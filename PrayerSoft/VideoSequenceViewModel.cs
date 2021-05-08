using System;

namespace PrayerSoft
{
    public class VideoSequenceViewModel
    {
        private readonly IVideoRepository videoRepository;

        public VideoSequenceViewModel(IVideoRepository videoRepository)
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