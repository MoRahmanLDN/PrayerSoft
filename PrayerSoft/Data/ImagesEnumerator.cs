namespace PrayerSoft.Data
{
    public class ImagesEnumerator: FileEnumerator
    {
        private readonly IFilesystem filesystem;
        private readonly IConfiguration configuration;

        public ImagesEnumerator(IFilesystem filesystem, IConfiguration configuration)
        {
            this.filesystem = filesystem;
            this.configuration = configuration;
        }

        public void Load()
        {
            var imagesPath = configuration.GetImagesPath();
            var imagesPattern = configuration.GetImagesPattern();
            files = filesystem.Search(imagesPath, imagesPattern);
        }
    }
}
