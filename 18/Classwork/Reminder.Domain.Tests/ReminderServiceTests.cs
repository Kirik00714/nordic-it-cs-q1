using System;
using System.Threading;
using NUnit.Framework;
using Reminder.Domain;
using Reminder.Domain.Tests;
using Reminder.Sender;

namespace Reminder.Storage.Memory.Tests
{
    public class ReminderServiceTests
    {
        private ReminderServiceParameters Parameters { get; } =
            new ReminderServiceParameters(
                createTimerInterval: TimeSpan.FromMilliseconds(50),
                createTimerDelay: TimeSpan.Zero,
                readyTimerInterval: TimeSpan.FromMilliseconds(50),
                readyTimerDelay: TimeSpan.Zero
            );

        private ReminderStorage Storage =>
            new ReminderStorage();

        private IReminderSender SuccessSender =>
            new ReminderSenderFake();

        private IReminderSender FailedSender =>
            new ReminderSenderFake(shouldRaiseError: true);

        [Test]
        public void ItemSent_WhenReminderNotificationSent_ShouldRaiseEvent()
        {
            // Arrange
            var eventRaised = false;
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(Storage, SuccessSender, receiver, Parameters);

            // Act
            service.ItemSent += (sender, args) => eventRaised = true;
            service.Start();
            receiver.Emit();
            WaitTimers();

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [Test]
        public void ItemFailed_WhenReminderNotificationFailed_ShouldRaiseEvent()
        {
            // Arrange
            var eventRaised = false;
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(Storage, FailedSender, receiver, Parameters);

            // Act
            service.ItemFailed += (sender, args) => eventRaised = true;
            service.Start();
            receiver.Emit();
            WaitTimers();

            // Assert
            Assert.IsTrue(eventRaised);
        }
        [Test]
        public void WhenStorage_IfNullSpecified_ShouldThrowException()
        {
            var receiver = new ReminderReceiverFake();
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(null, FailedSender, receiver, Parameters));
        }
        [Test]
        public void WhenFailedSender_IfNullSpecified_ShouldThrowException()
        {
            var receiver = new ReminderReceiverFake();
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(Storage, null, receiver, Parameters));
        }
        [Test]
        public void WhenReminderReceiverFake_IfNullSpecified_ShouldThrowException()
        {
            var receiver = new ReminderReceiverFake();
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(Storage, FailedSender, null, Parameters));
        }
        [Test]
        public void WhenParameters_IfNullSpecified_ShouldThrowException()
        {
            var receiver = new ReminderReceiverFake();
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(Storage, FailedSender, receiver, null));
        }
        [Test]
        public void WhenItemsSent_IfAddTwoItemsWithDifferentStatus_ShouldRaiseEvent()
        {

            // Arrange
            var item = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", DateTimeOffset.Now, ReminderItemStatus.Ready);
            var item2 = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", DateTimeOffset.Now, ReminderItemStatus.Created);
            var eventRaised = false;
            
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(new ReminderStorage(item), SuccessSender, receiver, Parameters);
            var service2 = new ReminderService(new ReminderStorage(item2), SuccessSender, receiver, Parameters);

            // Act
            service.ItemSent += (sender, args) => eventRaised = true;
            service2.ItemSent += (sender, args) => eventRaised = true;
            service.Start();
            service2.Start();
            receiver.Emit();
            WaitTimers();

            // Assert
            for (int i = 0; i < 2; i++)
            {
                Assert.IsTrue(eventRaised);
            }
           
            
        }
        [Test]
        public void WhenItemSent_IfAddTwoItemsWithDifferentStatus_ShouldRaiseEvent()
        {

            // Arrange
            var item = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", DateTimeOffset.Now, ReminderItemStatus.Sent);
            var item2 = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", DateTimeOffset.Now, ReminderItemStatus.Failed);
            var eventRaised = false;
            var eventRaised2 = false;
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(new ReminderStorage(item), SuccessSender, receiver, Parameters);
            var service2 = new ReminderService(new ReminderStorage(item2), FailedSender, receiver, Parameters);

            // Act
            service.ItemSent += (sender, args) => eventRaised = true;
            service2.ItemSent += (sender, args) => eventRaised2 = true;
            service.Start();
            service2.Start();
            receiver.Emit();
            WaitTimers();

            // Assert
            Assert.AreNotEqual(eventRaised, eventRaised2);
        }
        [Test]
        public void WhenItemSent_IfTimeDifferent_ShouldRaiseEvent()
        {

            // Arrange
            
            var time = new DateTimeOffset(2021, 01, 18, 03, 40, 00, new TimeSpan(+3, 0, 0));
            var timeNow = DateTimeOffset.Now;
            var item = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", DateTimeOffset.Now, ReminderItemStatus.Created);
            var item2 = new ReminderItem(Guid.NewGuid(), "ContactId", "Mesage", time, ReminderItemStatus.Created);
            var eventRaised = false;
            var eventRaised2 = false;
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(new ReminderStorage(item), SuccessSender, receiver, Parameters);
            var service2 = new ReminderService(new ReminderStorage(item2), SuccessSender, receiver, Parameters);

            // Act
            service.ItemSent += (sender, args) => eventRaised = true;
            if (timeNow > time)
            {
                service2.ItemSent += (sender, args) => eventRaised2 = true;
            }
            else
            {
                service2.ItemSent += (sender, args) => eventRaised2 = false;
            }
            
            service.Start();
            service2.Start();
            receiver.Emit();
            WaitTimers();

            // Assert
            
                Assert.AreNotEqual(eventRaised, eventRaised2);
               
            
            
            
        }

        private void WaitTimers()
        {
            Thread.Sleep(
                (Parameters.CreateTimerDelay + Parameters.ReadyTimerDelay) * 2 +
                (Parameters.CreateTimerInterval + Parameters.ReadyTimerInternval) * 2
            );
        }
    }
}