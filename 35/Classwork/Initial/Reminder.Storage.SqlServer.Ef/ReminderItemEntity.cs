using System;

namespace Reminder.Storage.SqlServer.Ef
{
	public class ReminderItemEntity
	{
		public Guid Id { get; set; }
		public string Message { get; set; }
		public DateTimeOffset DatetimeUtc { get; set; }
		public ReminderItemStatus Status { get; set; }
		public ContactEntity Contact { get; set; }
		public DateTimeOffset CreatedDatetimeUtc { get; set; }
		public DateTimeOffset ModifiedDatetimeUtc { get; set; }

		public ReminderItemEntity()
		{
		}

		public ReminderItemEntity(ReminderItem item, ContactEntity contact)
		{
			Id = item.Id;
			Message = item.Message;
			DatetimeUtc = item.DatetimeUtc;
			Status = item.Status;
			Contact = contact;
		}
	}
}