namespace PrayerSoft
{
    public interface ISequenceViewModel: IViewModel
    {
        bool HasEnded { get; }
        void Reset();
    }
}
