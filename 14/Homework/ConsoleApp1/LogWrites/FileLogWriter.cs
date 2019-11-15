using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        private static FileLogWriter instance;
        private FileLogWriter()
        { }
        public static FileLogWriter GetInstance
        {
            get
            {
                return instance ??
                    (instance = new FileLogWriter());
            }
        }
        public string Filename;
        protected override void WriteMessage(string line) =>
            File.AppendAllText(Filename, line);

    }
}
