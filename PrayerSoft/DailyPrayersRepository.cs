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
        List<DailyPrayerTimes> prayerTimes;

        public DailyPrayerTimes Get(DateTime date)
        {
            return prayerTimes.Find(pt =>
                pt.Date.Year == date.Year &&
                pt.Date.Month == date.Month &&
                pt.Date.Day == date.Day);
        }

        public void Load(string csv)
        {
            using (var stringReader = new StringReader(csv))
            using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
            {
                prayerTimes = csvReader.GetRecords<DailyPrayerTimes>().ToList();
            }
        }
    }
}