using System;
using System.IO;

namespace ConsoleApp1
{
    class MiltipleLogWriter : AbstractLogWriter, ILogWriter
    {
        public MiltipleLogWriter(ILogWriter filewriter, ILogWriter consolewriter)
        {
            this.filewriter = filewriter;
            this.consolewriter = consolewriter;
        }

        private ILogWriter filewriter { get; set; }
        private ILogWriter consolewriter { get; set; }
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
