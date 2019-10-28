using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminderItem = new ReminderItem(new DateTime(2019, 10, 29, 16, 52, 30), "Good morning! Time to get up!")
            {
            };
            reminderItem.WriteProperties();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
