using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                decimal deposit = default;
                decimal storage = default;
                decimal income = default;

                Console.WriteLine("Enter the amount of the down payment in rubles:");
                deposit = decimal.Parse(Console.ReadLine());
                if (deposit < 0)
                {
                    throw new ArgumentException("The amount of the down paymen is not correct");
                }

                Console.WriteLine("Enter the daily percentage of income as a decimal (1% = 0,01):");
                income = decimal.Parse(Console.ReadLine());
                if (income < 0)
                {
                    throw new ArgumentException("The daily percentage of income is not correct");
                }

                Console.WriteLine("Enter the desired amount of savings in rubles:");
                storage = decimal.Parse(Console.ReadLine());
                if (storage < 0)
                {
                    throw new ArgumentException("The daily percentage of income is not correct");
                }

                int day = default;
                while (deposit < storage)
                {
                    deposit *= (1 + income);
                    day++;
                }
                Console.WriteLine($"The requires number of days to accumulate the desire amount: {day}");
            }
            catch (ArgumentException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            catch (OverflowException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            catch (FormatException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            Console.WriteLine("Please enter any key..");
        }
    }
}
