using System.Windows;
using System.Windows.Controls;

namespace PrayerSoft.UI.Controls
{
    public class Video: MediaElement
    {
        public Video()
        {
            MediaOpened += Video_MediaOpened;
            MediaEnded += Video_MediaEnded;
        }

        private void Video_MediaOpened(object sender, RoutedEventArgs e)
        {
            SetValue(HasEndedProperty, false);
        }

        private void Video_MediaEnded(object sender, RoutedEventArgs e)
        {
            SetValue(HasEndedProperty, true);
        }

        public bool HasEnded
        {
            get { return (bool)GetValue(HasEndedProperty); }
            set { SetValue(HasEndedProperty, value); }
        }

        public static readonly DependencyProperty HasEndedProperty =
            DependencyProperty.Register("HasEnded", typeof(bool), typeof(Video), new PropertyMetadata(false));
    }
}
