using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string containing parenthese. For exemple '(', ')', '[', ']'");
            Stack<char> bracket = new Stack<char>();
            Stack<char> bracket1 = new Stack<char>();

            var str = Console.ReadLine();

            foreach (var ch in str)
            {
                if (ch == '(')
                {
                    bracket.Push(ch);
                }
                else if (ch == ')')
                {
                    if (bracket.Count == 0)
                    {
                        Console.WriteLine(false);
                        break;
                    }

                    else
                    {
                        bracket.Pop();
                    }
                }


                if (ch == '[')
                {

                    bracket1.Push(ch);

                }
                else if (ch == ']')
                {
                    if (bracket1.Count == 0)
                    {
                        Console.WriteLine(false);
                        break;
                    }

                    else
                    {
                        bracket1.Pop();
                    }
                }

            }
            if (bracket.Count == 0 && bracket1.Count == 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }





            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }


}
}
