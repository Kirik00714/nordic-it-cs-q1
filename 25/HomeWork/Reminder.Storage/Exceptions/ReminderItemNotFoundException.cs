using System;

namespace Reminder.Storage.Exceptions
{
	public class ReminderItemNotFoundException : Exception
	{
		public ReminderItemNotFoundException(Guid id) :
			base($"Reminder item with id {id} not found")
		{
		}

		public ReminderItemNotFoundException(string message) :
			base(message)
		{
		}
	}
}
