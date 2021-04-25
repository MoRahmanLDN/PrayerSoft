using System;
using System.Windows.Threading;

namespace PrayerSoft
{
    public class MainWindowViewModel
    {
        public CurrentTimeViewModel Today { get; set; }

        public MainWindowViewModel()
        {
            var clock = new Clock();
            Today = new CurrentTimeViewModel(clock);

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTick;
            timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            Today.Refresh();
        }
    }
}
