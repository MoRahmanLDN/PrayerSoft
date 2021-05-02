using System.IO;

namespace PrayerSoft
{
    public class ImagesRepository: IImagesRepository
    {
        private string[] images;

        public void Load(string path)
        {
            images = Directory.GetFiles(path);
        }

        private int index;

        public string GetNextImage()
        {
            if (index == images.Length)
            {
                index = 0;
            }
            return images[index++];
        }
    }
}