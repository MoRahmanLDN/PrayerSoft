namespace PrayerSoft
{
    public class MainWindowViewModel
    {
        public CurrentTimeViewModel Today { get; set; }

        public MainWindowViewModel()
        {
            var clock = new Clock();
            Today = new CurrentTimeViewModel(clock);

            Today.Refresh();
        }
    }
}
