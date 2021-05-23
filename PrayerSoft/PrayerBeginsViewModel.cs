using PrayerSoft.Data;
using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class PrayerBeginsViewModel : IViewModel
    {
        private readonly PrayerVideos prayerVideos;

        public string PrayerName { get; set; }
        public string Video { get; set; }
        public bool HasEnded { get; set; }

        public PrayerBeginsViewModel(PrayerVideos prayerVideos)
        {
            this.prayerVideos = prayerVideos;
        }

        public void Refresh()
        {
            Video = prayerVideos.Get(PrayerName);
        }
    }
}
