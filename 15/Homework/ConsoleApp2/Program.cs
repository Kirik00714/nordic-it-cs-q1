using System;

namespace ConsoleApp2
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory()
        { }
        public static LogWriterFactory GetInstance()
        {
            return instance ??
                (instance = new LogWriterFactory());
        }
        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {
            
                if (typeof(T) == typeof(ConsoleLogWriter))
                {
                    return new ConsoleLogWriter();
                }
                else if (typeof(T) == typeof(FileLogWriter))
                {
                    if (!string.IsNullOrWhiteSpace((string)parameters))
                    {
                        return new FileLogWriter((string)parameters);
                    }
                    else
                    {
                    return null;
                    }
                }
                else if (typeof(T) == typeof(MiltipleLogWriter))
                {
                return new MiltipleLogWriter((ILogWriter[])parameters);
                }
                else
                {
                return null;
                }
            
            

        }

        class Program
        {
            static void Main(string[] args)
            {
                var logwriterfactory = LogWriterFactory.GetInstance();
                var consolelogwriter = logwriterfactory.GetLogWriter<ConsoleLogWriter>(null);
                consolelogwriter.LogInfo("Message for Info");
                consolelogwriter.LogWarning("Message for Warning");
                consolelogwriter.LogError("Message for Error");

                var filelogwriter = logwriterfactory.GetLogWriter<FileLogWriter>("File.txt");
                filelogwriter.LogInfo("Message for Info");
                filelogwriter.LogWarning("Message for Warning");
                filelogwriter.LogError("Message for Error");
                Console.WriteLine("");

                ILogWriter[] ilogwriters = new ILogWriter[] { consolelogwriter, filelogwriter };

                var miltilogwriter = logwriterfactory.GetLogWriter<MiltipleLogWriter>(ilogwriters);
                miltilogwriter.LogInfo("Message for Info");
                miltilogwriter.LogWarning("Message for Warning");
                miltilogwriter.LogError("Message for Error");

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
