using System;

namespace ConsoleApp1
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        protected override void WriteMessage(string line) => 
            Console.WriteLine(line);
    }
}
