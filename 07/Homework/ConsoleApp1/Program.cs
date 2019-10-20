using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter string:");
                string str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Empty string");
                    continue;
                }
                var words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (words.Length <= 1)
                    {
                        throw new ArgumentException("You have entered too few words");
                    }
                    int count = default;
                    foreach (var word in words)
                    {
                        if (word[0] == 'A' || word[0] == 'a' || word[0] == 'А' || word[0] == 'а')
                        {
                            count++; ;
                        }
                    }
                    Console.WriteLine($"Numbers of words beginning with a lette <А>:{count}");
                    Console.WriteLine("Press any key to exit");
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
