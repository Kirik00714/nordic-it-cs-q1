using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static double  Mert (string title)
        {
            while (true)
            {
                Console.WriteLine(title);
                if (double.TryParse(Console.ReadLine(), out var Operand))
                {
                    return Operand;

                }
                Console.WriteLine("Wrong value");
            }
        }

        static char oper ()
        {
            while (true)
            {
                Console.WriteLine("Enter the operation: ");
                var input = Console.ReadLine();
                if (IsOperator (input))
                {
                    return input [0];
                }
                Console.WriteLine("Wrong operation");
            }
        }

        static bool IsOperator (string input)
        {
            var operation = new char[] { '+', '-', '*', '/', '%', '^'};

            if(string.IsNullOrWhiteSpace (input))
            {
                return false;
            }

            for (int i = 0; i < operation.Length; i++)
            {
                if (operation[i] == input[0])
                {
                return true;
                }
            }
            return false;
             
        }
        static void Main()
        {
            var firstOperand = Mert("enter the first number ");
            var secondOperand = Mert("enter the second number ");
            var operation = oper();
           

            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}");
                    break;
                case '-':
                    Console.WriteLine($"{firstOperand} - {secondOperand} = {firstOperand - secondOperand}");
                    break;
                case '*':
                    Console.WriteLine($"{firstOperand} * {secondOperand} = {firstOperand * secondOperand}");
                    break;
                case '/':
                    Console.WriteLine($"{firstOperand} / {secondOperand} = {firstOperand / secondOperand}");
                    break;
                case '%':
                    Console.WriteLine($"{firstOperand} % {secondOperand} = {firstOperand % secondOperand}");
                    break;
                case '^':
                    Console.WriteLine($"{firstOperand} ^ {secondOperand} = {Math.Pow(firstOperand,secondOperand)}");
                    break;
                default:
                    Console.WriteLine($"Wrong value");
                    break;
            }
            Console.ReadKey();
        }
       

    }
}
