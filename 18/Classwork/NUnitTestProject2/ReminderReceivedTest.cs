using NUnit.Framework;
using Reminder.Receiver;
using System;

namespace Reminder.Received.Test
{
    public class ReminderReceivedTest
    {
        [Test]
        public void WhenMessage_IfOneMessageHasNoFieldsFilledIn_ShouldEmptyString()
        {
            var receiver = new MessageReceivedEventArgs("123", new Message("some text", DateTimeOffset.UtcNow));
            var receiver1 = new MessageReceivedEventArgs("123", new Message(null, default));
            Assert.AreNotEqual(receiver, receiver1);
        }
        [Test]
        public void WhenMessage_IfOneMessageHasNoFieldsFilledIn_ShouldEmptyText()
        {
            var receiver = new MessageReceivedEventArgs("123", new Message("some text", DateTimeOffset.UtcNow));
            var receiver1 = new MessageReceivedEventArgs("123", new Message(null,DateTimeOffset.UtcNow));
            Assert.AreNotEqual(receiver, receiver1);
        }
        [Test]
        public void WhenMessage_IfOneMessageHasNoFieldsFilledIn_ShouldEmptyDateTime()
        {
            var receiver = new MessageReceivedEventArgs("123", new Message("some text", DateTimeOffset.UtcNow));
            var receiver1 = new MessageReceivedEventArgs("123", new Message("Some text1", default));
            Assert.AreNotEqual(receiver, receiver1);
        }
    }
}