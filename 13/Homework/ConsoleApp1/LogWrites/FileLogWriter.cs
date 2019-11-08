using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : AbstractLogWriter, ILogWriter 
    {
        private readonly string _writer;

        public  FileLogWriter(string filename)
        {
            _writer = filename;
        }

        public  string LogFileName { get; }

        protected override void WriteMessage(string line) => 
            File.AppendAllText(_writer, line);

    }
}
