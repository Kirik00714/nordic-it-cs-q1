using System;

namespace Reminder.Storage.Exceptions
{
	public class ReminderItemDuplicateException : Exception
	{
		public ReminderItemDuplicateException(Guid id) :
			base($"Reminder item with id {id} already exists")
		{
		}

		public ReminderItemDuplicateException(string message) :
			base(message)
		{
		}
	}
}
