using PrayerSoft.Data;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrayerSoft.UI
{
    public partial class Shell : Window
    {
        private bool isFullscreen;
        private Filesystem filesystem;
        private Configuration configuration;
        private Calendar calendar;
        private ImagesEnumerator imagesEnumerator;
        private VideosEnumerator videosEnumerator;
        private TimeSpan slideshowInterval;
        private MessageEnumerator messageEnumerator;
        private TimeSpan messageInterval;

        public Shell()
        {
            InitializeComponent();

            filesystem = new Filesystem();
            configuration = new Configuration();
            var clock = new Clock();
            calendar = new Calendar(filesystem, configuration);
            imagesEnumerator = new ImagesEnumerator(filesystem, configuration);
            videosEnumerator = new VideosEnumerator(filesystem, configuration);
            messageEnumerator = new MessageEnumerator(filesystem, configuration);
            DataContext = new ShellViewModel(
                clock, 
                configuration,
                calendar, 
                imagesEnumerator, 
                videosEnumerator, 
                messageEnumerator);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            Refresh();
            SetRefreshTimer();
        }

        private void LoadData()
        {
            calendar.Load();
            imagesEnumerator.Load();
            videosEnumerator.Load();
            messageEnumerator.Load();
        }

        private void Refresh()
        {
            ((IViewModel)DataContext).Refresh();
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
