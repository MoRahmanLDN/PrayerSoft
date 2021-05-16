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

        public MessageEnumerator(IFilesystem filesystem, IConfiguration configuration)
        {
            this.filesystem = filesystem;
            this.configuration = configuration;
        }

        private readonly IFilesystem filesystem;
        private readonly IConfiguration configuration;

        private List<MessageRecord> messages = new List<MessageRecord>();
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

        public void Load()
        {
            var csvPath = configuration.GetMessagesPath();
            var csvData = filesystem.Read(csvPath);

            messages = Csv.Read<MessageRecord>(csvData);
        }
    }
}