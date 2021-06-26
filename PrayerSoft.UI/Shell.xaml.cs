using PrayerSoft.Data;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrayerSoft.UI
{
    public partial class Shell : Window
    {
        private bool isFullscreen;
        
        public Shell()
        {
            InitializeComponent();

            var clock = new Clock();
            var filesystem = new Filesystem();
            var configuration = new Configuration();
            var calendar = new Calendar(filesystem, configuration);
            var ramadan = new Ramadan(filesystem, configuration);

            DataContext = new ShellViewModel(clock, filesystem, configuration, calendar, ramadan);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            Refresh();
            SetRefreshTimer();
        }

        private void LoadData()
        {
            ((ShellViewModel)DataContext).Load();
        }

        private void Refresh()
        {
            ((ShellViewModel)DataContext).Refresh();
        }

        private void SetRefreshTimer()
        {
            var interval = TimeSpan.FromSeconds(1);
            var priority = DispatcherPriority.Normal;
            EventHandler callback = (sender, eventArgs) => Refresh();

            var timer = new DispatcherTimer(interval, priority, callback, Dispatcher);
            timer.Start();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                ToggleFullScreen();
            }
        }

        private void ToggleFullScreen()
        {
            isFullscreen = !isFullscreen;

            if (isFullscreen)
            {
                this.Visibility = Visibility.Collapsed;
                this.Topmost = true;
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
                this.Visibility = Visibility.Visible;
            }
            else
            {   
                this.Topmost = false;
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }
    }
}
