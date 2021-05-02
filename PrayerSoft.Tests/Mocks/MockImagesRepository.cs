using System.Collections.Generic;

namespace PrayerSoft.Tests
{
    public class MockImagesRepository: IImagesRepository
    {
        public List<string> Images { get; set; }

        private int currentIndex;
        
        public string GetNextImage()
        {
            if (currentIndex == Images.Count)
            {
                currentIndex = 0;
            }
            return Images[currentIndex++];
        }
    }
}