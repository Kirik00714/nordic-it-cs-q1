using System;
namespace Reminder.Storage
{
    public class ReminderItemFilter
    {
        public DateTimeOffset? DateTime { get; private set; }
        public RemindetItenStatus? Status { get; private set; }
        public ReminderItemFilter At(DateTimeOffset datetime)
        {
            DateTime = datetime;
            return this;
        }
        public ReminderItemFilter Created()
        {
            Status = RemindetItenStatus.Created;
            return this;
        }
    }
}
