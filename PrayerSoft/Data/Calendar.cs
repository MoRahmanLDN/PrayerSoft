using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

        Dictionary<string, DailySchedule> days;
        private const string DateFormat = "yyyy-MM-dd";

        public DailySchedule Get(DateTime date)
        {
            return days[date.ToString(DateFormat)];
        }

        public void Load(string csv)
        {
            using (var stringReader = new StringReader(csv))
            using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
            {
                days = csvReader.GetRecords<CsvRecord>().ToDictionary(
                    record => record.Date.ToString(DateFormat),
                    record => Map(record));
            }
        }

        private DailySchedule Map(CsvRecord record)
        {
            return new DailySchedule
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
                IshaJamaat = Combine(record.Date, record.IshaJamaat),

                Sunrise = Combine(record.Date, record.Sunrise),
                Sunset = Combine(record.Date, record.Sunset),
                SubSadiq = Combine(record.Date, record.SubSadiq),
                Zawaal = Combine(record.Date, record.Zawaal),
            };
        }

        private DateTime Combine(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }
}