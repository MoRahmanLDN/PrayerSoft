using System.Collections.Generic;

namespace PrayerSoft.Data
{
    public interface IFilesystem
    {
        string Read(string filename);
        List<string> Search(string path, string pattern);
    }
}