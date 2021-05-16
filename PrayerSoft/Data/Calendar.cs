using PrayerSoft.Utilities;
using System;
using System.Collections.Generic;

namespace PrayerSoft.Data
{
    public class Calendar : ICalendar
    {
        public class CsvRecord
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

            public DateTime Sunrise { get; set; }
            public DateTime Sunset { get; set; }
            public DateTime SubSadiq { get; set; }
            public DateTime Zawaal { get; set; }
        }

        public Calendar(IFilesystem filesystem, IConfiguration configuration)
        {
            this.filesystem = filesystem;
            this.configuration = configuration;
        }

        private readonly IFilesystem filesystem;
        private readonly IConfiguration configuration;

        Dictionary<string, List<Prayer>> prayers = new Dictionary<string, List<Prayer>>();
        Dictionary<string, TimesOfDay> timesOfDay = new Dictionary<string, TimesOfDay>();
        
        public List<Prayer> GetPrayers(DateTime date)
        {
            return prayers[Date.Hash(date)];
        }

        public TimesOfDay GetTimesOfDay(DateTime date)
        {
            return timesOfDay[Date.Hash(date)];
        }

        public void Load()
        {
            var csvPath = configuration.GetCalendarPath();
            var csvData = filesystem.Read(csvPath);
            var records = Csv.Read<CsvRecord>(csvData);

            foreach (var record in records)
            {
                prayers[Date.Hash(record.Date)] = MapPrayer(record);
                timesOfDay[Date.Hash(record.Date)] = MapTimesOfDay(record);
            }
        }

        private List<Prayer> MapPrayer(CsvRecord record)
        {
            return new List<Prayer>
            {
                new Prayer
                {
                    Name = "Fajr",
                    Begins = Date.Combine(record.Date, record.FajrBegins),
                    Jamaat = Date.Combine(record.Date, record.FajrJamaat)
                },
                new Prayer
                {
                    Name="Zuhr",
                    Begins = Date.Combine(record.Date, record.ZuhrBegins),
                    Jamaat = Date.Combine(record.Date, record.ZuhrJamaat),
                },
                new Prayer
                {
                    Name="Asr",
                    Begins = Date.Combine(record.Date, record.AsrBegins),
                    Jamaat = Date.Combine(record.Date, record.AsrJamaat),
                },
                new Prayer
                {
                    Name = "Maghrib",
                    Begins = Date.Combine(record.Date, record.MaghribBegins),
                    Jamaat = Date.Combine(record.Date, record.MaghribJamaat),
                },
                new Prayer
                {
                    Name = "Isha",
                    Begins = Date.Combine(record.Date, record.IshaBegins),
                    Jamaat = Date.Combine(record.Date, record.IshaJamaat),
                }
            };
        }

        private TimesOfDay MapTimesOfDay(CsvRecord record)
        {
            return new TimesOfDay
            {
                Sunrise = Date.Combine(record.Date, record.Sunrise),
                Sunset = Date.Combine(record.Date, record.Sunset),
                SubSadiq = Date.Combine(record.Date, record.SubSadiq),
                Zawaal = Date.Combine(record.Date, record.Zawaal),
            };
        }
    }
}