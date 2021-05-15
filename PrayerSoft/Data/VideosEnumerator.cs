namespace PrayerSoft.Data
{
    public class VideosEnumerator : FileEnumerator
    {
        private readonly IFilesystem filesystem;
        private readonly IConfiguration configuration;

        public VideosEnumerator(IFilesystem filesystem, IConfiguration configuration)
        {
            this.filesystem = filesystem;
            this.configuration = configuration;
        }

        public void Load()
        {
            var videosPath = configuration.GetVideosPath();
            var videosPattern = configuration.GetVideosPattern();
            files = filesystem.Search(videosPath, videosPattern);
        }
    }
}
