using System;
using NUnit.Framework;

namespace Reminder.Storage.Memory.Tests
{
    public class ReminderStorageTests
    {
        // WhenUnit_IfCondition_ShouldExpectedResult

        [Test]
        public void WhenCreate_IfEmptyStorage_ShouldFindItemById()
        {
            // Arrange
            var item = CreateReminderItem();
            var storage = new ReminderStorage();

            // Act
            storage.Create(item);

            // Assert
            var result = storage.FindById(item.Id);
            Assert.AreEqual(item.Id, result.Id);
        }

        [Test]
        public void WhenCreate_IfNullSpecified_ShouldThrowException()
        {
            // Arrange
            var storage = new ReminderStorage();

            // Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                storage.Create(null)
            );
        }

        [Test]
        public void WhenCreate_IfExistsElementWithKey_ShouldThrowException()
        {
            // Arrange
            var item = CreateReminderItem();
            var storage = new ReminderStorage(
                item
            );

            // Act-Assert
            Assert.Catch<ArgumentException>(() =>
                storage.Create(item)
            );
        }

        [Test]
        public void WhenFindBy_IfNullFilterSpecifeid_ShouldThrowException()
        {
            // Arrange
            var storage = new ReminderStorage();

            // Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                storage.FindBy(default)
            );
        }

        [Test]
        public void WhenFindBy_IfStatusSpecified_ShouldFilterByStatus()
        {
            // Arrange
            var storage = new ReminderStorage(
                CreateReminderItem(status: ReminderItemStatus.Created)
            );

            // Act
            var result = storage.FindBy(
                ReminderItemFilter.ByStatus(ReminderItemStatus.Created)
            );

            // Assert
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void WhenUpdate_IfKeyElementNotFound_ShouldThrowException()
        {
            var item = CreateReminderItem();
            var storage = new ReminderStorage();
            Assert.Catch<ArgumentException>(() =>
                storage.Update(item));
        }
        [Test]
        public void WhenUpdate_IfItemIsNull_ShouldThrowException()
        {
            var storage = new ReminderStorage();
            Assert.Catch<ArgumentNullException>(() =>
                storage.Update(null));
        }
        [Test]
        public void WhenUpdate_IfItemSpecified_ShouldUpdateCorrectly()
        {
            var item = CreateReminderItem();
            var storage = new ReminderStorage(item);

            var newItem = CreateReminderItem(id: item.Id, status: ReminderItemStatus.Ready);
            storage.Update(newItem);

            var status = ReminderItemStatus.Ready;

            Assert.AreEqual(status, storage.FindById(item.Id).Status);
               
        }

        private ReminderItem CreateReminderItem(
            Guid? id = default,
            string contactId = default,
            string message = default,
            DateTimeOffset? messageDate = default,
            ReminderItemStatus? status = default)
        {
            if (!id.HasValue)
            {
                id = Guid.NewGuid();
            }
            if (contactId == null)
            {
                contactId = "123";
            }
            if (message == null)
            {
                message = "Some text";
            }
            if (!messageDate.HasValue)
            {
                messageDate = DateTimeOffset.UtcNow;
            }
            if (!status.HasValue)
            {
                status = ReminderItemStatus.Created;
            }
            return new ReminderItem(id.Value, contactId, message, messageDate.Value, status.Value);
        }
    }
}