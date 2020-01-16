using System;
using System.Data;
using Microsoft.Data.SqlClient;
using NUnit.Framework;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.SqlServer.Tests
{
	public class ReminderStorageCreator
	{
		private readonly string _connectionString;

		public ReminderStorageCreator(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void CreateTables()
		{
			ExecuteScript(Sql.CreateContactTable);
			ExecuteScript(Sql.CreateReminderItemStatusTable);
			ExecuteScript(Sql.InsertReminderItemStatusLines);
			ExecuteScript(Sql.CreateReminderItemTable);
		}

		public void CreateProcedures()
		{
			ExecuteScript(Sql.AddReminderItem);
		}

		public void DropProcedures()
		{
			ExecuteScript("DROP PROCEDURE IF EXISTS [sp_AddReminderItem];");
		}

		public void DropTables()
		{
			ExecuteScript("DROP TABLE IF EXISTS [ReminderItem];");
			ExecuteScript("DROP TABLE IF EXISTS [ReminderItemStatus];");
			ExecuteScript("DROP TABLE IF EXISTS [Contact];");
		}

		private void ExecuteScript(string script)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Open();

			using var command = connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = script;
			command.ExecuteNonQuery();
		}
	}

	public class ReminderStorageTests
	{
		public const string ConnectionString = "Server=tcp:shadow-art.database.windows.net,1433;Initial Catalog=reminder; Persist Security Info=False;User ID=app_testing@shadow-art;Password=XCrzJjTRqX43uzaEpJNj;Encrypt=True;";
		public ReminderStorageCreator Creator { get; } =
			new ReminderStorageCreator(ConnectionString);

		[OneTimeSetUp]
		public void Setup()
		{
			Creator.CreateTables();
			Creator.CreateProcedures();
		}

		[OneTimeTearDown]
		public void Teardown()
		{
			//Creator.DropProcedures();
			//Creator.DropTables();
		}

		[Test]
		public void WhenAdd_IfStorageIsEmpty_ShouldReturnCreatedItemById()
		{
			// Arrange
			var item = new ReminderItem(Guid.NewGuid(), "CONTACT", "Message", DateTimeOffset.UtcNow);
			var storage = new ReminderStorage(ConnectionString);

			// Act
			storage.Add(item);

			// Assert
			var result = storage.FindById(item.Id);
			Assert.AreEqual(item.Id, result.Id);
		}

		[Test]
		public void WhenAdd_IfItemAlreadyExists_ShouldThrow()
		{
			// Arrange
			var item = new ReminderItem(Guid.NewGuid(), "CONTACT", "Message", DateTimeOffset.UtcNow);
			var storage = new ReminderStorage(ConnectionString);

			// Act
			storage.Add(item);

			// Assert
			Assert.Catch<ReminderItemDuplicateException>(() =>
				storage.Add(item)
			);
		}

		[Test]
		public void WhenFindById_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var storage = new ReminderStorage(ConnectionString);

			// Act-Assert
			Assert.Throws<ReminderItemNotFoundException>(() =>
				storage.FindById(Guid.NewGuid())
			);
		}

		[Test]
		public void WhenUpdate_IfItemExists_ShouldReturnUpdatedItem()
		{
			// Arrange
			var id = Guid.NewGuid();
			var item = new ReminderItem(id, "CONTACT", "Message", DateTimeOffset.UtcNow);
			var storage = new ReminderStorage(ConnectionString);
			storage.Add(item);

			// Act
			storage.Update(new ReminderItem(id, "CONTACT", "Message updated", DateTimeOffset.UtcNow));

			// Assert
			var result = storage.FindById(item.Id);
			Assert.AreEqual("Message updated", result.Message);
		}

		[Test]
		public void WhenUpdate_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var item = new ReminderItem(Guid.NewGuid(), "CONTACT", "Message", DateTimeOffset.UtcNow);
			var storage = new ReminderStorage(ConnectionString);

			// Act-Assert
			Assert.Throws<ReminderItemNotFoundException>(() =>
				storage.Update(item)
			);
		}

		// FindBy
		// 1. Ввыполняется фильтрация
		// 2. Выполняется постраничная выгрузка
		// Как?
		// Создать Н с разными значениями
		// Status: Ready, Datetime: 2019.12.12, Message: m1
		// Status: Ready, Datetime: 2019.12.12, Message: m2
		// Status: Ready, Datetime: 2019.12.12, Message: m3
		// Status: Sent, Datetime: 2019.12.12, Message: m1
		// Status: Ready, Datetime: 2019.12.13, Message: m1
		// Создать фильтр с определенными параметрамми
		// Status: Ready, Datetime: 2019.12.12
		// Выполнить запрос
		// Проверить что получаем ровно 3 элемента
	}
}
