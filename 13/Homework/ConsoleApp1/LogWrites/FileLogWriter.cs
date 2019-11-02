using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : AbstractLogWriter, ILogWriter 
    {
        private readonly StreamWriter _writer;

        public  FileLogWriter(string logFileName)
        {
            LogFileName = logFileName;
            _writer = File.AppendText(logFileName);
        }

        public  string LogFileName { get; }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            _writer.WriteLine(message);
            _writer.Flush();
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            _writer.WriteLine(message);
            _writer.Flush();
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            _writer.WriteLine(message);
            _writer.Flush();
        }
        
    }
}
