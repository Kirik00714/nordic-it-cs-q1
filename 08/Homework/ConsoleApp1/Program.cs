using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Enter a string containing parenthese. For exemple '(', ')', '[', ']'");
            string str;
            do
            {
                str = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(str));
            Console.WriteLine(CountBracket(str));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

         static bool CountBracket(string line)
         {
            Stack<char> brackets = new Stack<char>();
           
            foreach (var ch in line)
            {
                if (ch == '(' || ch == '[')
                {
                    brackets.Push(ch);
                    
                }
                else if (ch == ')' || ch == ']')
                {
                    if (brackets.Count == 0 || (brackets.Peek() != '(' || brackets.Peek() != '['))
                    {
                        return false;
                        
                    }
                    else
                    {
                        brackets.Pop();
                        
                    }
                }
            }
            return brackets.Count == 0; 
         }
    }
}
