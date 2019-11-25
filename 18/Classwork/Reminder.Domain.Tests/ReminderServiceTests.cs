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

        private void WaitTimers()
        {
            Thread.Sleep(
                (Parameters.CreateTimerDelay + Parameters.ReadyTimerDelay) * 2 +
                (Parameters.CreateTimerInterval + Parameters.ReadyTimerInternval) * 2
            );
        }
    }
}