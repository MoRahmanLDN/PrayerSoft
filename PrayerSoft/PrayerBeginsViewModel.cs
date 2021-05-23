using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class PrayerBeginsViewModel : IViewModel
    {
        private readonly IPrayerVideos prayerVideos;
        
        public string PrayerName { get; set; }
        public string Video { get; set; }
        public bool HasEnded { get; set; }

        public PrayerBeginsViewModel(IPrayerVideos prayerVideos)
        {
            this.prayerVideos = prayerVideos;
        }

        public void Refresh()
        {
            var newVideo = prayerVideos.Get(PrayerName);
            if (newVideo != Video)
            {
                HasEnded = false;
                Video = newVideo;
            }
        }
    }
}
