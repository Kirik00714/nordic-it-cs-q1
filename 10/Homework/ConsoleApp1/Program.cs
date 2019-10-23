using System;

namespace ConsoleApp1
{
    class Human
    {

        public string Name;
        public  int Age;
        
        public int AfterFourYears
            => Age + 4;
        
        public string Description
            => $"Name: {Name}, age in 4 years: {AfterFourYears}.";


    }
    class Program
    {
        static void Main(string[] args)
        {

            var people = new Human[3];
            for (int i = 0; i < people.Length; i++)
            {
                while (true)
                {
                    Console.Write($" {i + 1}. Name:");
                    people[i] = new Human
                    {

                        Name = Console.ReadLine()
                    };
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
                    people[i] = new Human
                    {
                        Age = int.Parse(Console.ReadLine())
                    };
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
