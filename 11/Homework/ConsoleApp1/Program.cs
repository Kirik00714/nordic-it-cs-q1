using System;

namespace ConsoleApp1
{
    class ReminderItem
    {
        public ReminderItem(DateTime alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public DateTime AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm =>
            AlarmDate - DateTime.Now;
        public bool IsOutdated
        {
            get
            {
                if (TimeToAlarm >= TimeSpan.Zero)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void WriteProperties()
        {
            Console.WriteLine($"AlarmDate: {AlarmDate}");
            Console.WriteLine($"AlarmMessage: {AlarmMessage}");
            Console.WriteLine($"TimeToAlarm: {TimeToAlarm}");
            Console.WriteLine($"IsOutdated: {IsOutdated}");    
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminderItem = new ReminderItem(new DateTime(2019, 10, 28, 16, 52, 30), "Good morning! Time to get up!")
            {
            };
            reminderItem.WriteProperties();
        }
    }
}
