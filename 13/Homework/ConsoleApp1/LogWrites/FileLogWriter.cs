using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : AbstractLogWriter, ILogWriter 
    {
        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            File.AppendAllText(@"C:\Users\Андрей\Desktop\File.txt", Message);
        }
        
    }
}
