using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : AbstractLogWriter, ILogWriter 
    {
        private readonly string _filename;

        public  FileLogWriter(string filename)
        {
            _filename = filename;
        }
        protected override void WriteMessage(string line) => 
            File.AppendAllText(_filename, line);

    }
}
