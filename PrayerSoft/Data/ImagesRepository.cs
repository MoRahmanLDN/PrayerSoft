using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrayerSoft.Data
{
    public class ImagesRepository : IImagesRepository
    {
        private List<string> images;

        public void Load(string folder, string pattern)
        {
            images = new DirectoryInfo(folder)
                .GetFiles(pattern)
                .Select(x => x.FullName)
                .ToList();
        }

        private int index;

        public string GetNextImage()
        {
            if (index == images.Count)
            {
                index = 0;
            }
            return images[index++];
        }
    }
}