using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string:");
            var word = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var err in word)
                {
                    if (err[0] == '1' || err[0] == '2' || err[0] == '3' || err[0] == '4' || err[0] == '5' || err[0] == '6' || err[0] == '7' || err[0] == '8' || err[0] == '9' || err[0] == '0')
                    {
                        throw new ArgumentException();
                    }
                }
                if (word.Length <= 1)
                {
                    Console.WriteLine("You have entered too few words");
                }
                int count = default;
                foreach (var words in word)
                {
                    if (words[0] == 'A' || words[0] == 'a' || words[0] == 'А' || words[0] == 'а')
                    {
                        count++; ;
                    }
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (ArgumentException wd)
            {
                Console.WriteLine(wd.Message);
            }
        }
    }
}
