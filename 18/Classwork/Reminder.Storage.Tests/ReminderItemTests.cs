using System;
using System.Collections.Generic;
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
        [Test]
        public void WhenReminderItem_IfStatusAnother_ShouldThrowException()
        {
            var item = new ReminderItem(Guid.NewGuid(), "123", "Some text", DateTimeOffset.UtcNow);
            Assert.Catch<InvalidOperationException>(() => item.Sent());
        }
        [Test]
        public void WhenReminderItem_IfTimeToAlarmSpecified_ShouldThrowException()
        {
            var dataTime = new DateTimeOffset(2020, 01, 17, 18, 49, 33, new TimeSpan(+3, 0, 0));
            var time = dataTime - DateTimeOffset.UtcNow;
            var item = new List<ReminderItem>
            {
                new ReminderItem(Guid.NewGuid(), "123", "Some text", dataTime),
                new ReminderItem(Guid.NewGuid(), "123", "Some text1", dataTime),
            };
            for (int i = 0; i < item.Count; i++)
            {
                Console.WriteLine($"{time}");
            }
        }
    }
}