using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount of the down payment in rubles:");
            decimal deposit = default;
           
            try
            {
                deposit = decimal.Parse(Console.ReadLine());
                if (deposit < 0 )
                {
                    throw new FormatException("The amount of the down paymen is not correct");
                }
            }
            catch (FormatException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            Console.WriteLine("Enter the daily percentage of income as a decimal (1% = 0,01):");
            decimal income = default;
            try
            {
                income = decimal.Parse(Console.ReadLine());
                if (income < 0)
                {
                    throw new FormatException("The daily percentage of income is not correct");
                }
            }
            catch (FormatException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            Console.WriteLine("Enter the desired amount of savings in rubles:");
            decimal storage = default;
            try
            {
                storage = decimal.Parse(Console.ReadLine());
                if (storage < 0)
                {
                    throw new FormatException("The daily percentage of income is not correct");
                }
            }
            catch (FormatException exp)
            {

                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            int day = default;
            while (deposit < storage)
            {
                deposit *= (1 + income);
                day++;
            }
            Console.WriteLine($"The requires number of days to accumulate the desire amount: {day}");
        }
    }
}
