namespace PrayerSoft
{
    public class LayoutEngine
    {
        private readonly ISequenceViewModel first;
        private readonly ISequenceViewModel second;
        private ISequenceViewModel current;

        public LayoutEngine(ISequenceViewModel first, ISequenceViewModel second)
        {
            this.first = first;
            this.second = second;
            current = first;
        }

        public ISequenceViewModel Choose()
        {
            if (current.HasEnded)
            {
                current = current == first ? second : first;
                current.Reset();
            }
            return current;
        }
    }
}