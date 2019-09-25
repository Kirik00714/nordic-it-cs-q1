using System;

namespace ConsoleApp1
{
    class Program
    {
            static void Main(string[] arg)
        {
           
            string[] name = new string[3];
            for (int i = 0; i < name.Length; i++)
            {
                int num = i + 1;
                Console.Write($"{num}. name:  ");
                name[i] = Console.ReadLine();

            }
            int [] age = new int[3];
            for (int i = 0; i < age.Length; i++)
            {
                int num = i + 1;
                Console.Write($"{num}. age:  ");
                age[i] = int.Parse(Console.ReadLine());

            }
            for (int i = 0; i < name.Length; i++)
            {
                
                Console.WriteLine($"Name: {name[i]}, age in 4 years: {age[i] + 4}");
            }
        }
    }
}
