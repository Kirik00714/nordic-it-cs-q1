using System;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string:");
            
            string str;
            do
            {
                str = Console.ReadLine().ToLower();
            } while (string.IsNullOrWhiteSpace(str));

            var inputLine = new StringBuilder(str);
            var outputLine = new StringBuilder();
            for (int i = inputLine.Length - 1; i >= 0; i--)
            {
                
                 outputLine.Append(str[i]);
            }
            Console.WriteLine(outputLine);
            Console.WriteLine("Press ane key to exit");
            Console.ReadKey();
        }
    }
}
