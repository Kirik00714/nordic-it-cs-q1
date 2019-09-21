using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Thread.Sleep(5000);
            Console.WriteLine($"Hello!");
            Console.ReadKey();
        }
    }
}
