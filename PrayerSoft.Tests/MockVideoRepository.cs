using PrayerSoft.Data;
using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    public class MockVideoRepository: IFileRepository
    {
        public MockVideoRepository()
        {
        }

        public List<string> Videos { get; internal set; }

        private int index;

        public string GetNext()
        {
            return Videos[index++];
        }
    }
}