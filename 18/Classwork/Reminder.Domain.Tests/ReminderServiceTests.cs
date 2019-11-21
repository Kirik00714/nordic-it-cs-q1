using NUnit.Framework;
using Reminder.Storage.Memory;

using System;
using System.Threading;

namespace Reminder.Domain.Tests
{
    public class ReminderServiceTests
    {
        
        [Test]
        public void ItemSend_WhenReminderItemAdded_ShouldRaiseEvent()
        {
            var storage = new ReminderStorage();
            var service = new ReminderService(storage);
            var eventRaise = false;

            service.ItemSent += (sender, args) => eventRaise = true;
            service.Create(new CreateReminderModel("Contactid", "Message", DateTimeOffset.Now));
            Thread.Sleep(TimeSpan.FromSeconds(4));
            Assert.IsTrue(eventRaise);
        }
    }
    private CreateReminderModel CreateReminderModel()
    {

    }
}