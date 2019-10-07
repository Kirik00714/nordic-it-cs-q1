using System;

namespace ConsoleApp1
{
    class Program
    {
        static uint ReadUinteger ()
        {
            var value = uint.Parse(Console.ReadLine());
            if (value < 0 )
            {
                throw new ArgumentException ("Enter a positive  natural number no more than 4 bilion: ");
            }
            
            return value;
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive  natural number no more than 4 bilion::");             
            
            
            while (true)
            {
                uint value = 0;
                try
                {
                    value = ReadUinteger();
                    Console.Write($"The number {value} ");
                    var count = 0;
                    do
                    {
                        if (value % 2 == 0)
                        {
                            count++;
                        }
                        value /= 10;
                    } while (value > 0);
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
                catch (ArgumentException exe)
                {
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Try again:");
                }
                Console.ReadKey();
            }

            
        }
            
    }
}
