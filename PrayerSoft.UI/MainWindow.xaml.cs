﻿using PrayerSoft.Data;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrayerSoft.UI
{
    public partial class MainWindow : Window
    {
        private bool isFullscreen;
        private Calendar calendar;
        private FileEnumerator imageEnumerator;
        private FileEnumerator videoEnumerator;
        private TimeSpan slideshowInterval;
        private MessageEnumerator messageEnumerator;
        private TimeSpan messageInterval;

        public MainWindow()
        {
            InitializeComponent();

            var clock = new Clock();
            calendar = new Calendar();
            imageEnumerator = new FileEnumerator();
            videoEnumerator = new FileEnumerator();
            slideshowInterval = TimeSpan.FromSeconds(5);
            messageEnumerator = new MessageEnumerator();
            messageInterval = TimeSpan.FromSeconds(5);
            DataContext = new MainWindowViewModel(
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
            calendar.Load(File.ReadAllText("Data/calendar.csv"));
            imageEnumerator.Load(@"Images", "*.jpg");
            videoEnumerator.Load(@"Videos", "*.mp4");
            messageEnumerator.Load(File.ReadAllText("Data/messages.csv"));
        }

        private void Refresh()
        {
            ((MainWindowViewModel)DataContext).Refresh();
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
