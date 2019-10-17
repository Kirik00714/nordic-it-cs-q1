using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string:");
            while (true)
            {
                string str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Empty string");
                    continue;
                }
                var word = str.ToLower();
               
                if (word == "")
                {
                    Console.WriteLine("You  entered an empty string");
                }
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    Console.Write(word[i]);
                }
                Console.WriteLine("\nPress ane key to exit");
                Console.ReadKey();
                break;
                
                
            }
        }
    }
}
