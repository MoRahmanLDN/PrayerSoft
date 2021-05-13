using System.Collections.Generic;

namespace PrayerSoft.Utilities
{
    public class Cycle
    {
        public static IEnumerable<int> Get(int startingIndex, int length)
        {
            for (int i = 0; i < length; i++)
            {
                yield return (startingIndex + i) % length;
            }
        }
    }
}
