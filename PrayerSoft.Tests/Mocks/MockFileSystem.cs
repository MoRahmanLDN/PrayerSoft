using PrayerSoft.Data;
using System.Collections.Generic;

namespace PrayerSoft.Tests.Mocks
{
    public class MockFilesystem: IFilesystem
    {
        public string FileContent { get; set; }
        public List<string> SearchResults { get; set; }

        public string Read(string filename)
        {
            return FileContent;
        }

        public List<string> Search(string path, string pattern)
        {
            return SearchResults;
        }
    }
}