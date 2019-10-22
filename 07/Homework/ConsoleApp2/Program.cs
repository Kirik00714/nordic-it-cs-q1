using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string:");
            
            string str;
            do
            {
                str = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(str));
                
            
            var word = str.ToLower();
            char[] symbols = word.ToCharArray();
            string finalword = default;
            for (int i = symbols.Length - 1; i >= 0; i--)
            {
                finalword += char.ToString(symbols[i]);
            }
            Console.WriteLine(finalword);
            Console.WriteLine("Press ane key to exit");
            Console.ReadKey();
        }
    }
}
