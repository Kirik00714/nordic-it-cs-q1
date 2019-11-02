using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var people = new Human[3];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Human();
                while (true)
                {
                    Console.Write($" {i + 1}. Name:");

                    people[i].Name = Console.ReadLine();
                    
                    if (!string.IsNullOrWhiteSpace(people[i].Name))
                    {
                        break;
                    }
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Enter again");
                }

                while (true)
                {
                    Console.Write($" {i + 1}. Age:");
                    try
                    {
                       
                       people[i].Age = int.Parse(Console.ReadLine());
                        if (people[i].Age > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                            Console.WriteLine("Enter again");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERROR");
                        Console.WriteLine("Enter again");
                    }
                }
            }
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(people[i].Description);
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }
    }

            

        
       
        
    
}
