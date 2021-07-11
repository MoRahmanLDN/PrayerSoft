using PrayerSoft.Data;

namespace PrayerSoft
{
    public class MosqueViewModel: IViewModel
    {
        private readonly IConfiguration configuration;

        public MosqueViewModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Name { get; set; }

        public void Refresh()
        {
            Name = configuration.GetMosqueName();
        }
    }
}