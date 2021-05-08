using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrayerSoft.Data
{
    public class FileRepository : IFileRepository
    {
        private List<string> files;

        public void Load(string folder, string pattern)
        {
            files = new DirectoryInfo(folder)
                .GetFiles(pattern)
                .Select(x => x.FullName)
                .ToList();
        }

        private int index;

        public string GetNext()
        {
            if (index == files.Count)
            {
                index = 0;
            }
            return files[index++];
        }
    }
}