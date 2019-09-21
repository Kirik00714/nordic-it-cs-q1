using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter value x");
            var x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter value y");
            var y = double.Parse(Console.ReadLine());
            Console.WriteLine($"{x} + {y} = {x + y} ");
            Console.WriteLine($"{x} - {y} = {x - y} ");
            Console.WriteLine($"{x} * {y} = {x * y} ");
        }
       
    }
}
