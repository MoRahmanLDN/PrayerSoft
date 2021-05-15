using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrayerSoft.Data
{
    public class Filesystem : IFilesystem
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }

        public List<string> Search(string path, string pattern)
        {
            return new DirectoryInfo(path)
                .GetFiles(pattern)
                .Select(x => x.FullName)
                .ToList();
        }
    }
}
