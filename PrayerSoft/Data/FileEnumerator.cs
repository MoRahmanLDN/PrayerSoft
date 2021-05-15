using System.Collections.Generic;

namespace PrayerSoft.Data
{
    public abstract class FileEnumerator : IFileEnumerator
    {
        protected List<string> files;
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