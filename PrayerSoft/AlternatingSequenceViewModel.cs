using PropertyChanged;

namespace PrayerSoft
{
    [AddINotifyPropertyChangedInterface]
    public class AlternatingSequenceViewModel: IViewModel
    {
        private readonly ISequenceViewModel first;
        private readonly ISequenceViewModel second;

        public ISequenceViewModel Current { get; set; }

        public AlternatingSequenceViewModel(ISequenceViewModel first, ISequenceViewModel second)
        {
            this.first = first;
            this.second = second;
            Current = first;
        }

        public void Refresh()
        {
            if (Current.HasEnded)
            {
                Current = Current == first ? second : first;
                Current.Reset();
            }
            Current.Refresh();
        }
    }
}