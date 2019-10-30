using System;

namespace ConsoleApp1
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            Console.WriteLine(Message);
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            Console.WriteLine(Message);
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            Console.WriteLine(Message);
        }
    }
}
