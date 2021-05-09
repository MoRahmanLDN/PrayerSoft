namespace PrayerSoft.UI.DesignTime
{
    class DailyScheduleDesignTimeViewModel
    {
        public string FajrBegins { get; set; } = "10:10";
        public string FajrJamaat { get; set; } = "11:11";
        
        public string ZuhrBegins { get; set; } = "12:12";
        public string ZuhrJamaat { get; set; } = "13:13";

        public string AsrBegins { get; set; } = "14:14";
        public string AsrJamaat { get; set; } = "15:15";

        public string MaghribBegins { get; set; } = "16:16";
        public string MaghribJamaat { get; set; } = "17:17";

        public string IshaBegins { get; set; } = "18:18";
        public string IshaJamaat { get; set; } = "19:19";

        public string Sunrise { get; set; } = "01:01";
        public string Sunset { get; set; } = "02:02";
        public string SubSadiq { get; set; } = "03:03";
        public string Zawaal { get; set; } = "04:04";
    }
}
