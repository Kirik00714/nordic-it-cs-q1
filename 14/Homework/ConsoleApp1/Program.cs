using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var filelogwriter = FileLogWriter.GetInstance;
            filelogwriter.Filename = "File.txt";
            filelogwriter.LogInfo("Message for Info");
            filelogwriter.LogWarning("Message for Warning");
            filelogwriter.LogError("Message for Error");

            var consolelogwriter = ConsoleLogWriter.GetInstance;
            consolelogwriter.LogInfo("Message for Info");
            consolelogwriter.LogWarning("Message for Warning");
            consolelogwriter.LogError("Message for Error");

            Console.WriteLine("");

            var miltipleogriter = new MiltipleLogWriter(consolelogwriter, filelogwriter);
            miltipleogriter.LogInfo("Message for Info");
            miltipleogriter.LogWarning("Message for Warning");
            miltipleogriter.LogError("Message for Error");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
