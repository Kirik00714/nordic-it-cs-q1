using System;
using System.IO;

namespace ConsoleApp1
{
    class MiltipleLogWriter : AbstractLogWriter, ILogWriter
    {
        public MiltipleLogWriter(string infoMessage, string warningMessage, string errorMessage)
        {
            InfoMessage = infoMessage;
            WarningMessage = warningMessage;
            ErrorMessage = errorMessage;
        }

        public string InfoMessage { get; set; }
        public string WarningMessage { get; set; }
        public string ErrorMessage { get; set; }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            Console.WriteLine(Message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
            
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            Console.WriteLine(Message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
            
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            Console.WriteLine(Message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
            
        }

    }
}
