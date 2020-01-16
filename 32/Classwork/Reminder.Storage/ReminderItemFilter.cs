using System;

namespace Reminder.Storage
{
	public class ReminderItemFilter
	{
		private readonly DateTimeOffset? _datetimeUtc;

		public DateTimeOffset DatetimeUtc =>
			_datetimeUtc.GetValueOrDefault();

		public ReminderItemStatus Status { get; }

		public PageInfo Page { get; }

		public bool ByDatetime =>
			_datetimeUtc.HasValue;

		public bool ByStatus =>
			Status != ReminderItemStatus.Undefied;

		public ReminderItemFilter(
			PageInfo page = default,
			DateTimeOffset? datetimeUtc = default,
			ReminderItemStatus status = ReminderItemStatus.Undefied)
		{
			Page = page ?? PageInfo.All;
			Status = status;
			_datetimeUtc = datetimeUtc;
		}
	}
}
