using PrayerSoft.Data;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    public class MockFileRepository: IFileRepository
    {
        public List<string> Files { get; set; }

        private int currentIndex;
        
        public string GetNext()
        {
            if (currentIndex == Files.Count)
            {
                currentIndex = 0;
            }
            return Files[currentIndex++];
        }
    }
}