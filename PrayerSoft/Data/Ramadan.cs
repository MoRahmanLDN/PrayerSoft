using PrayerSoft.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrayerSoft.Data
{
    public class Ramadan : IRamadan
    {
        public class CsvRecord
        {
            public DateTime Date { get; set; }
            public DateTime SuhurEnds { get; set; }
            public DateTime IftarBegins { get; set; }
            public DateTime FirstTaraweeh { get; set; }
            public DateTime SecondTaraweeh { get; set; }
        }

        private readonly IFilesystem filesystem;
        private readonly IConfiguration configuration;
        private DateTime startDate;
        private DateTime endDate;

        Dictionary<string, CsvRecord> prayers = new Dictionary<string, CsvRecord>();

        public Ramadan(IFilesystem filesystem, IConfiguration configuration)
        {
            this.filesystem = filesystem;
            this.configuration = configuration;
        }

        public void Load()
        {
            var csvPath = configuration.GetRamadanPath();
            var csvData = filesystem.Read(csvPath);
            var records = Csv.Read<CsvRecord>(csvData);

            foreach (var record in records)
            {
                AdjustDates(record);
                prayers[Date.Hash(record.Date)] = record;
            }

            startDate = records.First().Date;
            endDate = records.Last().Date;
        }

        private void AdjustDates(CsvRecord record)
        {
            record.SuhurEnds = Date.Combine(record.Date, record.SuhurEnds);
            record.IftarBegins = Date.Combine(record.Date, record.IftarBegins);
            record.FirstTaraweeh = Date.Combine(record.Date, record.FirstTaraweeh);
            record.SecondTaraweeh = Date.Combine(record.Date, record.SecondTaraweeh);
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }

        public DateTime GetSuhurEnds(DateTime now)
        {
            return prayers[Date.Hash(now)].SuhurEnds;
        }

        public DateTime GetIftarBegins(DateTime now)
        {
            return prayers[Date.Hash(now)].IftarBegins;
        }

        public DateTime GetFirstTaraweeh(DateTime now)
        {
            return prayers[Date.Hash(now)].FirstTaraweeh;
        }

        public DateTime GetSecondTaraweeh(DateTime now)
        {
            return prayers[Date.Hash(now)].SecondTaraweeh;
        }
    }
}
