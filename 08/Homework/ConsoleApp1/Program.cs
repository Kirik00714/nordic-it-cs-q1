using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> bracket = new Queue<string>();
            int count = default;
            var value = Console.ReadLine();
            while (true)
            {

                bracket.Enqueue((value));
                if (value == "go")
                {
                    count = Outputbracket(count, value);

                    if (count == 0)
                    {
                        Console.WriteLine(true);
                    }
                    else
                    {
                        Console.WriteLine(false);
                    }

                }
            }
        }

        static int Outputbracket(int count, string value)
        {

            while (true)
            {
                if (value == "(")
                {
                    count++;
                }
                else if (value == ")")
                {
                    count--;
                }

                return count;
            }
        }
       
        



        

         
        
       
        
    }
}
