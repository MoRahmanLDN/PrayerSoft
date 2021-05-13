using CsvHelper;
using PrayerSoft.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PrayerSoft.Data
{
    public class MessageEnumerator : IMessageEnumerator
    {
        public class MessageRecord
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Message { get; set; }
        }

        private List<MessageRecord> messages;

        private int currentIndex;

        public string GetNext(DateTime now)
        {
            var indexes = Cycle.Get(currentIndex, messages.Count);
            foreach (var index in indexes)
            {
                if (Match(messages[index], now))
                {
                    currentIndex = index + 1;
                    return messages[index].Message;
                }
            }
            return null;
        }

        private bool Match(MessageRecord record, DateTime now)
        {
            return record.StartDate < now
                && record.EndDate > now;
        }

        public void Load(string csv)
        {
            using (var stringReader = new StringReader(csv))
            using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
            {
                messages = csvReader.GetRecords<MessageRecord>().ToList();
            }
        }
    }
}