using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Enter a string containing parenthese. For exemple '(', ')', '[', ']', '{', '}'");
            var str = Console.ReadLine();
            Console.WriteLine(CountBracket(str));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

         static bool CountBracket(string line)
         {
            Stack<char> bracket = new Stack<char>();
           
            foreach (var ch in line)
            {
                if (ch == '(')
                {
                    bracket.Push(ch);
                    
                }
                else if (ch == ')')
                {
                    if (bracket.Count == 0 || bracket.Peek() != ')' )
                    {
                        return false;
                        
                    }
                    else
                    {
                        bracket.Pop();
                        
                    }
                }
            }
            if (bracket.Count == 0)
            {
                return true;
            }
            return bracket.Count == 0;
            
         }

    }



}
