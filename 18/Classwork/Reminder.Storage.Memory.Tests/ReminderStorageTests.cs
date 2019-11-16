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
	}
}