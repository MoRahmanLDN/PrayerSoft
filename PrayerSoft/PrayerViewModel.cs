using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class PrayerViewModel
    {
        public string PrayerName { get; set; }
        public string Begins { get; set; }
        public string Jamaat { get; set; }
        public bool IsNext { get; set; }
    }
}
