using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace PrayerSoft.UI
{
    public class StyleConfig
    {
        private static JObject style;

        public static Color BackgroundColor { get; set; }
        public static Color TextColor { get; set; }
        public static Color SplitterColor { get; set; }

        public static FontFamily MessagesFontFamily { get; set; }
        public static double MessagesFontSize { get; set; }
        public static FontWeight MessagesFontWeight { get; set; }

        public static FontFamily MosqueNameFontFamily { get; set; }
        public static double MosqueNameFontSize { get; set; }
        public static FontWeight MosqueNameFontWeight { get; set; }

        public static Color AlternatingColor1 { get; set; }
        public static Color AlternatingColor2 { get; set; }
        
        static StyleConfig()
        {
            Load();
        }

        public static void Load()
        {
            style = JObject.Parse(File.ReadAllText("style.json"));

            BackgroundColor = GetColor("BackgroundColor");
            TextColor = GetColor("TextColor");
            SplitterColor = GetColor("SplitterColor");

            MessagesFontFamily = GetFont("MessagesFontFamily");
            MessagesFontSize = GetDouble("MessagesFontSize");
            MessagesFontWeight = GetFontWeight("MessagesFontWeight");

            MosqueNameFontFamily = GetFont("MosqueNameFontFamily");
            MosqueNameFontSize = GetDouble("MosqueNameFontSize");
            MosqueNameFontWeight = GetFontWeight("MosqueNameFontWeight");

            AlternatingColor1 = GetColor("AlternatingColor1");
            AlternatingColor2 = GetColor("AlternatingColor2");
        }

        private static Color GetColor(string name)
        {
            return (Color)ColorConverter.ConvertFromString(style.Value<string>(name));
        }

        private static FontFamily GetFont(string name)
        {
            return new FontFamily(style.Value<string>(name));
        }

        private static double GetDouble(string name)
        {
            return style.Value<double>(name);
        }

        private static FontWeightConverter fontWeightConverter = new FontWeightConverter();

        private static FontWeight GetFontWeight(string name)
        {
            return (FontWeight)fontWeightConverter.ConvertFromString(style.Value<string>(name));
        }
    }
}
