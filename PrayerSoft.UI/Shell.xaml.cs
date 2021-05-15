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
        private FileEnumerator imageEnumerator;
        private FileEnumerator videoEnumerator;
        private TimeSpan slideshowInterval;
        private MessageEnumerator messageEnumerator;
        private TimeSpan messageInterval;

        public Shell()
        {
            InitializeComponent();

            filesystem = new Filesystem();
            configuration = new Configuration();
            var clock = new Clock();
            calendar = new Calendar();
            imageEnumerator = new FileEnumerator();
            videoEnumerator = new FileEnumerator();
            slideshowInterval = configuration.GetImagesInterval();
            messageEnumerator = new MessageEnumerator();
            messageInterval = configuration.GetMessagesInterval();
            DataContext = new ShellViewModel(
                clock, 
                calendar, 
                imageEnumerator, 
                videoEnumerator, 
                slideshowInterval, 
                messageEnumerator, 
                messageInterval);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            Refresh();
            SetRefreshTimer();
        }

        private void LoadData()
        {
            var calendarPath = configuration.GetCalendarPath();
            var calendarData = filesystem.Read(calendarPath);
            calendar.Load(calendarData);

            var imagesPath = configuration.GetImagesPath();
            var imagesPattern = configuration.GetImagesPattern();
            imageEnumerator.Load(imagesPath, imagesPattern);

            var videosPath = configuration.GetVideosPath();
            var videosPattern = configuration.GetVideosPattern();
            videoEnumerator.Load(videosPath, videosPattern);

            var messagesPath = configuration.GetMessagesPath();
            var messagesData = filesystem.Read(messagesPath);
            messageEnumerator.Load(messagesData);
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
