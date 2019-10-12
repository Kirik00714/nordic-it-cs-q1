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
                var word = Console.ReadLine();
                try
                {
                    
                    foreach (var err in word)
                    {
                        if (err == '1' || err == '2' || err == '3' || err == '4' || err == '5' || err == '6' || err == '7' || err == '8' || err == '9' || err == '0')
                        {
                            throw new ArgumentException();
                        }
                    }
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
                catch (ArgumentException wd)
                {

                    Console.WriteLine(wd.Message);

                }
            }
        }
    }
}
