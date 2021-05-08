using PrayerSoft.Data;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    public class MockFileRepository: IFileEnumerator
    {
        public List<string> Files { get; set; }

        public bool IsComplete => index == Files.Count;

        private int index;
        
        public string GetNext()
        {
            return Files[index++];
        }

        public void Reset()
        {
            index = 0;
        }
    }
}