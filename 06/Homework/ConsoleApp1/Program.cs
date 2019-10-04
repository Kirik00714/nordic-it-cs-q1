using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive  natural number no more than 4 bilion:");             
            bool a = true;
            var count = 0; 
            while (a)
            {
                try
                {
                    var Number = uint.Parse(Console.ReadLine());
                    Console.Write($"The number {Number} ");
                    a = false;
                    do
                    {
                        if (Number % 2 == 0)
                        {
                            count++;
                        }
                        Number /= 10;
                    } while (Number > 0);
                    Console.Write($"contains the following number of eve numerals: {count}");
                }               
                catch (OverflowException exe )
                {
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Try again:");

                }
                catch (FormatException exe )
                {
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Try again:");

                }
            }
            Console.ReadKey();
        }
            
    }
}
