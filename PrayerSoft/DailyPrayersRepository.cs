using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PrayerSoft
{
    public class DailyPrayerTimesRepository: IPrayerTimesRepository
    {
        public class DailyPrayerTimesRecord
        {
            public DateTime Date { get; set; }
            
            public DateTime FajrBegins { get; set; }
            public DateTime FajrJamaat { get; set; }

            public DateTime ZuhrBegins { get; set; }
            public DateTime ZuhrJamaat { get; set; }

            public DateTime AsrBegins { get; set; }
            public DateTime AsrJamaat { get; set; }

            public DateTime MaghribBegins { get; set; }
            public DateTime MaghribJamaat { get; set; }

            public DateTime IshaBegins { get; set; }
            public DateTime IshaJamaat { get; set; }
        }

        Dictionary<string, DailyPrayerTimes> prayerTimes;
        private const string DateFormat = "yyyy-MM-dd";

        public DailyPrayerTimes Get(DateTime date)
        {
            return prayerTimes[date.ToString(DateFormat)];
        }

        public void Load(string csv)
        {
            using (var stringReader = new StringReader(csv))
            using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
            {
                prayerTimes = csvReader.GetRecords<DailyPrayerTimesRecord>().ToDictionary(
                    record => record.Date.ToString(DateFormat),
                    record => Map(record));
            }
        }

        private DailyPrayerTimes Map(DailyPrayerTimesRecord record)
        {
            return new DailyPrayerTimes
            {
                FajrBegins = Combine(record.Date, record.FajrBegins),
                FajrJamaat = Combine(record.Date, record.FajrJamaat),

                ZuhrBegins = Combine(record.Date, record.ZuhrBegins),
                ZuhrJamaat = Combine(record.Date, record.ZuhrJamaat),

                AsrBegins = Combine(record.Date, record.AsrBegins),
                AsrJamaat = Combine(record.Date, record.AsrJamaat),
                
                MaghribBegins = Combine(record.Date, record.MaghribBegins),
                MaghribJamaat = Combine(record.Date, record.MaghribJamaat),

                IshaBegins = Combine(record.Date, record.IshaBegins),
                IshaJamaat = Combine(record.Date, record.IshaJamaat)
            };
        }

        private DateTime Combine(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }
}