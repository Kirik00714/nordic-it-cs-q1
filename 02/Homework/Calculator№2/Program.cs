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
            Console.WriteLine("Enter operation sign");
            var sign = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter value y");
            var y = double.Parse(Console.ReadLine());
            if (sign == '+')
            {
                Console.WriteLine($"{x} + {y} = {x + y}");
            }
            else if (sign == '-')
            {
                Console.WriteLine($"{x} - {y} = {x - y}");
            }
            else if (sign == '*')
            {
                Console.WriteLine($"{x} * {y} = {x * y}");
            }
            else if (sign == '/')
            {
                Console.WriteLine($"{x} / {y} = {x / y}");
            }
            else if (sign == '%')
            {
                Console.WriteLine($"{x} % {y} = {x % y}");
            }
            else if (sign == '^')
            {
                Console.WriteLine($"{x} ^ {y} = {Math.Pow(x,y)}");
            }
            Console.ReadKey();
        }
       

    }
}
