using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrayerSoft.UI.Controls
{
    public partial class Prayer : UserControl
    {
        public Prayer()
        {
            InitializeComponent();
        }

        public string PrayerName
        {
            get { return (string)GetValue(PrayerNameProperty); }
            set { SetValue(PrayerNameProperty, value); }
        }

        public static readonly DependencyProperty PrayerNameProperty =
            DependencyProperty.Register("PrayerName", typeof(string), typeof(Prayer), new PropertyMetadata(string.Empty));

        public string Begins
        {
            get { return (string)GetValue(BeginsProperty); }
            set { SetValue(BeginsProperty, value); }
        }

        public static readonly DependencyProperty BeginsProperty =
            DependencyProperty.Register("Begins", typeof(string), typeof(Prayer), new PropertyMetadata(string.Empty));

        public string Jamaat
        {
            get { return (string)GetValue(JamaatProperty); }
            set { SetValue(JamaatProperty, value); }
        }

        public static readonly DependencyProperty JamaatProperty =
            DependencyProperty.Register("Jamaat", typeof(string), typeof(Prayer), new PropertyMetadata(string.Empty));
    }
}
