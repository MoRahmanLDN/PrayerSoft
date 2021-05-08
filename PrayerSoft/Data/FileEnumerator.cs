using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrayerSoft.Data
{
    public class FileEnumerator : IFileEnumerator
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

        public bool IsComplete => index == files.Count;

        public string GetNext()
        {
            return files[index++];
        }

        public void Reset()
        {
            index = 0;
        }
    }
}