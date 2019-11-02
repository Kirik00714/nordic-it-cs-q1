using System;
using System.IO;

namespace ConsoleApp1
{
    class MiltipleLogWriter : AbstractLogWriter, ILogWriter
    {
        public MiltipleLogWriter(FileLogWriter filewriter, ConsoleLogWriter consolewriter)
        {
            this.filewriter = filewriter;
            this.consolewriter = consolewriter;
        }

        public  FileLogWriter filewriter { get; set; }
        public  ConsoleLogWriter consolewriter { get; set; }
        

        public override void LogInfo(string message)
        {
            filewriter.LogInfo(message);
            consolewriter.LogInfo(message);
            
        }
        public override void LogWarning(string message)
        {
            filewriter.LogWarning(message);
            consolewriter.LogWarning(message);

        }
        public override void LogError(string message)
        {
            filewriter.LogError(message);
            consolewriter.LogError(message);

        }

    }
}
