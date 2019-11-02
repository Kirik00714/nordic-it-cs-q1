using System;

namespace ConsoleApp1
{
    class Program
    { 
    
        static void Main(string[] args)
        {
            var filelogwriter = new FileLogWriter("File.txt");
            filelogwriter.LogInfo("Message for Info");
            filelogwriter.LogWarning("Message for Warning");
            filelogwriter.LogError("Message for Error") ;

            var consolelogwriter = new ConsoleLogWriter();
            consolelogwriter.LogInfo("Message for Info");
            consolelogwriter.LogWarning("Message for Warning");
            consolelogwriter.LogError("Message for Error");
            Console.WriteLine("");
            var miltipleogriter = new MiltipleLogWriter(filelogwriter , consolelogwriter );
            miltipleogriter.LogInfo("Message for Info");
            miltipleogriter.LogWarning("Message for Warning");
            miltipleogriter.LogError("Message for Error");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }
    }
}
