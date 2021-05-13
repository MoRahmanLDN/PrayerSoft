using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrayerSoft.Data;
using System;

namespace PrayerSoft.Tests
{
    [TestClass]
    public class MessageEnumeratorTests
    {
        private MessageEnumerator enumerator;

        [TestInitialize]
        public void Initialize()
        {
            enumerator = new MessageEnumerator();
        }

        [TestMethod]
        public void ReturnNullIfNoMessagesDefined()
        {
            var csv = "StartDate,EndDate,Message\r\n";
            enumerator.Load(csv);

            var message = enumerator.GetNext(new DateTime());

            Assert.IsNull(message);
        }

        [TestMethod]
        public void ReturnsNullIfNoMessagesMatchDate()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-05-10 00:00,2022-05-30 23:59,Message\r\n" +
                "2022-05-20 00:00,2022-05-30 23:59,Message\r\n" +
                "2022-05-25 00:00,2022-05-30 23:59,Message\r\n";

            enumerator.Load(csv);

            var message = enumerator.GetNext(DateTime.Parse("2022-06-01 00:00"));

            Assert.IsNull(message);
        }

        [TestMethod]
        public void ReturnsFirstMessageIfItMatchesDate()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-05-10 00:00,2022-05-30 23:59,Message\r\n";

            enumerator.Load(csv);

            var message = enumerator.GetNext(DateTime.Parse("2022-05-20 00:00"));

            Assert.AreEqual("Message", message);
        }

        [TestMethod]
        public void ReturnsSecondMessageIfItIsTheFirstOneThatMatchesDate()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-05-10 00:00,2022-05-20 23:59,Message1\r\n" +
                "2022-05-20 00:00,2022-05-30 23:59,Message2\r\n";

            enumerator.Load(csv);

            var message = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));

            Assert.AreEqual("Message2", message);
        }

        [TestMethod]
        public void ReturnsMessagesInSequence()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-05-10 00:00,2022-05-30 23:59,Message1\r\n" +
                "2022-05-20 00:00,2022-05-30 23:59,Message2\r\n" +
                "2022-05-22 00:00,2022-05-30 23:59,Message3\r\n";

            enumerator.Load(csv);

            var message1 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));
            var message2 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));
            var message3 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));

            Assert.AreEqual("Message1", message1);
            Assert.AreEqual("Message2", message2);
            Assert.AreEqual("Message3", message3);
        }

        [TestMethod]
        public void AlwaysReturnsSameMessagesIfItIsOnlyOne()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-05-20 00:00,2022-05-30 23:59,Message\r\n";

            enumerator.Load(csv);

            var message1 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));
            var message2 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));

            Assert.AreEqual("Message", message1);
            Assert.AreEqual("Message", message2);
        }

        [TestMethod]
        public void AlwaysReturnsSameMessagesIfItIsOnlyOneThatMatchesDate()
        {
            var csv =
                "StartDate,EndDate,Message\r\n" +
                "2022-04-20 00:00,2022-04-30 23:59,Message1\r\n" +
                "2022-05-20 00:00,2022-05-30 23:59,Message2\r\n" +
                "2022-06-20 00:00,2022-06-30 23:59,Message3\r\n";

            enumerator.Load(csv);

            var message1 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));
            var message2 = enumerator.GetNext(DateTime.Parse("2022-05-25 00:00"));

            Assert.AreEqual("Message2", message1);
            Assert.AreEqual("Message2", message2);
        }
    }
}
