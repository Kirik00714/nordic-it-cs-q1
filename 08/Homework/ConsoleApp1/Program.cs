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
            int count1 = default;
            int count2 = default;
            while (true)
            {
                var value = Console.ReadLine();
                bracket.Enqueue((value));
                count = Outputbracket(count, value);
                count1 = Outputbracket1(count1, value);
                count2 = Outputbracket2(count2, value);
                if (count == 0 && count1 == 0 && count2 == 0 )
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
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
        static int Outputbracket1(int count1, string value)
        {

            while (true)
            {
                if (value == "{")
                {
                    count1++;
                }
                else if (value == "}")
                {
                    count1--;
                }

                return count1;
            }
        }
        static int Outputbracket2(int count2, string value)
        {

            while (true)
            {
                if (value == "[")
                {
                    count2++;
                }
                else if (value == "]")
                {
                    count2--;
                }

                return count2;
            }
        }
    }
}
