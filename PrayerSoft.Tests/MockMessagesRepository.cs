using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests
{
    class MockMessagesRepository: IMessageEnumerator
    {
        public MockMessagesRepository()
        {
        }

        public string Message { get; internal set; }

        public string GetNext(DateTime now)
        {
            return Message;
        }
    }
}