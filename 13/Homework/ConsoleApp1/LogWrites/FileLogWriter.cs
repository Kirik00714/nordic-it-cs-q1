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
            
            _writer.WriteLine(OutputMessage(message));
            _writer.Flush();
        }
        public override void LogWarning(string message)
        {
            
            _writer.WriteLine(OutputMessage(message));
            _writer.Flush();
        }
        public override void LogError(string message)
        {
            
            _writer.WriteLine(OutputMessage(message));
            _writer.Flush();
        }
        
    }
}
