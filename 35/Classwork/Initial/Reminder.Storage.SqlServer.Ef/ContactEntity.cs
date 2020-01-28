using System;
using System.Collections.Generic;

namespace Reminder.Storage.SqlServer.Ef
{
	public class ContactEntity
	{
		public Guid Id { get; set; }
		public string Login { get; set; }

		public ICollection<ReminderItemEntity> Reminders { get; set; } =
			new List<ReminderItemEntity>();

		public ContactEntity()
		{
		}

		public ContactEntity(string login)
		{
			Id = Guid.NewGuid();
			Login = login;
		}
	}
}