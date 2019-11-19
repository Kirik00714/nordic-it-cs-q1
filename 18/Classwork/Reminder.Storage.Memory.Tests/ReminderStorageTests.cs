using NUnit.Framework;
using System;

namespace Reminder.Storage.Memory.Tests
{
	
	public class ReminderStorageTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void WhenCreate_IfEmptStorage_ShuldFindItembyId()
		{
			var item = new ReminderItem(Guid.NewGuid(), "123", "Some text", DateTimeOffset.Now);
			var storage = new ReminderStorage();

			storage.Create(item);

			var result = storage.FindById(item.Id);

			Assert.AreEqual(item.Id, result.Id);

		}
		[Test]
		public void WhenCreate_IfNullSpecified_ShuldThrowException()
		{
			var storage = new ReminderStorage();

			Assert.Catch<ArgumentNullException>(() =>
				storage.Create(null));
		}
		[Test]
		public void WhenCreate_IfExistElementWithKey_ShuldThrowException()
		{
			var item = new ReminderItem(Guid.NewGuid(), "123", "Some text", DateTimeOffset.Now);
			var storage = new ReminderStorage(item);

			Assert.Catch<ArgumentException>(() =>
				storage.Create(item));
			
		}
        [Test]
        public void WhenFyndBy_IfNullFilterSpecifeid_ShuldThrowException()
        {
            var storage = new ReminderStorage();

            Assert.Catch<ArgumentException>(() =>
                storage.FindBy(default));

        }
        [Test]
        public void WhenFyndBy_IsStatusSpecified_ShuldFilterByIt()
        {
            //Arrange
            var dateTime = DateTimeOffset.Parse("12.11.2019 14:28:00.120");
            
            var storage = new ReminderStorage(CreateReminderStorage(messageDate: DateTime.Parse("12.11.2019 14:28:00.120")));
            //Act
            var result = storage.FindBy(DateTimeOffset.Parse("12.11.2019 14:30:00.000"));
            //Assert
            Assert.IsNotEmpty(result);
        }

        private CreateReminderStorage( Guid? id = default, string contactId = default,... )
    }
}