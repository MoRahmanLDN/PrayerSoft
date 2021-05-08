namespace PrayerSoft.Data
{
    public interface IFileEnumerator
    {
        string GetNext();
        bool IsComplete { get; }
        void Reset();
    }
}