using System;

namespace PrayerSoft.Data
{
    public interface IMessageEnumerator
    {
        string GetNext(DateTime now);
    }
}