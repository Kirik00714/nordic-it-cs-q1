using System;
using System.Collections.Generic;
using System.Text;


namespace Reminder.Domain
{
    class ConsoleLogWriter : ILogWriter
    {
        public void LogCreated(string message)
        {
            Console.WriteLine("Created");
        }

        public void LogFailed(string message)
        {
            Console.WriteLine("Failed");
        }

        public void LogReady(string message)
        {
            Console.WriteLine("Ready");
        }

        public void LogSent(string message)
        {
            Console.WriteLine("Sent");
        }
        

    }

}
