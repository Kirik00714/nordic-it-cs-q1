using System;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Reminder notifier].. starting");
            var storage = new ReminderStorage();
            Console.ReadKey();

        }
    }
}
