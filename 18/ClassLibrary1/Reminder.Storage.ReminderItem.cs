using System;

namespace Reminder.Storage
{

	public class ReminderItem
	{
        
		public Guid Id { get; private set; }
		public string ContactId { get; private set; }
		public string Message { get; private set; }
		public DateTimeOffset MessageData { get; private set; }
		public RemindetItenStatus Status { get; private set; }

		public ReminderItem(Guid id, string contactId, string message, DateTimeOffset messageData, RemindetItenStatus status = RemindetItenStatus.Created)
		{
			if (id == default)
			{
				throw new ArgumentException("Идентификатор пустой", nameof(id));
			}
			if (string.IsNullOrWhiteSpace(contactId))
			{
				throw new ArgumentException("Идентификатор контакта пустой", nameof(contactId));
			}
			if (string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("Идентификатор контакта пустой", nameof(message));
			}
			if (messageData == default)
			{
				throw new ArgumentException("Дата сообщения не верная", nameof(messageData));
			}

			Id = id;
			ContactId = contactId;
			Message = message;
			MessageData = messageData;
			Status = status;
		}

        public void ReadyToSend()
        {
            if (Status != RemindetItenStatus.Created)
            {
                throw new InvalidOperationException("Неккоректный статус");
            }
            Status = RemindetItenStatus.Ready;
        }
    }
}
