using System;
using NUnit.Framework;
using Reminder.Storage;

namespace Tests
{
    public class ReminderItemTests
    {

        [Test]
        public void WhenReminderItem_IfNullIdSpecified_ShouldThrowException()
        {
            
            Assert.Catch<ArgumentException>(() =>
                new ReminderItem(default, "123", "Some text", DateTimeOffset.UtcNow));
        }
        [Test]
        public void WhenReminderItem_IfNullContactIdSpecified_ShouldThrowException()
        {

            Assert.Catch<ArgumentException>(() => 
                new ReminderItem(Guid.NewGuid(), null, "Some text", DateTimeOffset.UtcNow));
        }
        [Test]
        public void WhenReminderItem_IfNullMessageSpecified_ShouldThrowException()
        {

            Assert.Catch<ArgumentException>(() => 
                new ReminderItem(Guid.NewGuid(), "123", null, DateTimeOffset.UtcNow));
        }
        [Test]
        public void WhenReminderItem_IfNullMessageDataSpecified_ShouldThrowException()
        {

            Assert.Catch<ArgumentException>(() => 
                new ReminderItem(Guid.NewGuid(), "123", "Some text", default));
        }
    }
}