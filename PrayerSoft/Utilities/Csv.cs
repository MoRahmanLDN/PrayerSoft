using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PrayerSoft.Utilities
{
    public class Csv
    {
        public static List<T> Read<T>(string csvData)
        {
            using (var stringReader = new StringReader(csvData))
            using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
            {
                return csvReader.GetRecords<T>().ToList();
            }
        }
    }
}
