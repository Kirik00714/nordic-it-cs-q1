using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminders = new List<ReminderItem>
            {
                new ReminderItem(new DateTime(2099, 10, 30, 9, 30, 00), "Good morning! Time to get up!"),
                new PhoneReminderItem(new DateTime(2020, 01, 01, 00, 00, 01), "Happy New Year", "+7(916) 777-77-77"),
                new ChatReminderItem(new DateTime(2019, 11, 12, 16, 00, 00), "Ask homework", "Friends", "What homework?")
            };

            for (int i = 0; i < reminders.Count; i++)
            {
                reminders[i].WriteProperties();
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
