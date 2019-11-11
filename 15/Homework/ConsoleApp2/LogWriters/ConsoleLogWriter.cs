using System;

namespace ConsoleApp2
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        protected override void WriteMessage(string line) =>
            Console.WriteLine(line);
    }
}
