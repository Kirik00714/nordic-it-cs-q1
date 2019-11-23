using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var logwriterfactory = LogWriterFactory.Instance;
            var consolelogwriter = logwriterfactory.GetLogWriter<ConsoleLogWriter>(null);
            consolelogwriter.LogInfo("Message for Info");
            consolelogwriter.LogWarning("Message for Warning");
            consolelogwriter.LogError("Message for Error");

            var filelogwriter = logwriterfactory.GetLogWriter<FileLogWriter>("File.txt");
            filelogwriter.LogInfo("Message for Info");
            filelogwriter.LogWarning("Message for Warning");
            filelogwriter.LogError("Message for Error");
            Console.WriteLine("");

            var ilogwriters = new ILogWriter[] { consolelogwriter, filelogwriter };

            var miltilogwriter = logwriterfactory.GetLogWriter<MiltipleLogWriter>(ilogwriters);
            miltilogwriter.LogInfo("Message for Info");
            miltilogwriter.LogWarning("Message for Warning");
            miltilogwriter.LogError("Message for Error");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
}
