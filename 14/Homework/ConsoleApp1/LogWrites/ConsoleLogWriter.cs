using System;

namespace ConsoleApp1
{
    
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static ConsoleLogWriter instance; 
        private ConsoleLogWriter()
        { }
        public static ConsoleLogWriter Instance
        {
            get
            {
                return instance ??
                (instance = new ConsoleLogWriter());
            }
        }
        protected override void WriteMessage(string line) =>
            Console.WriteLine(line);
    }
}
