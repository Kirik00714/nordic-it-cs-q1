using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string containing parenthese. For exemple '(', ')', '[', ']', '{', '}' ");
            Stack<char> bracket = new Stack<char>();
            Stack<char> bracket1 = new Stack<char>();
            Stack<char> bracket2 = new Stack<char>();

            var str = Console.ReadLine();
            
            foreach (var ch in str)
            {
                CountingBracket(bracket, ch);
                
            }
            
            if (bracket.Count == 0 && bracket1.Count == 0 && bracket2.Count == 0)
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

        static void CountingBracket(Stack<char> bracket, char ch)
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
                }
                else
                {
                    bracket.Pop();
                }
            }
        }
    }
}
