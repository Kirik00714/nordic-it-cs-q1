using System;

namespace ConsoleApp1
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        public override void LogInfo(string message)
        {

            Console.WriteLine(OutputMessage(message));
        }
        public override void LogWarning(string message)
        {

            Console.WriteLine(OutputMessage(message));
        }
        public override void LogError(string message)
        {

            Console.WriteLine(OutputMessage(message));
        }
    }
}
