﻿using System;

namespace ConsoleApp1
{
    class Human
    {

        public string Name;
        public  int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }
        public int AfterFourYears
            => age + 4;
        
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
                    people[i].age = int.Parse(Console.ReadLine());
                    
                    if (people[i].age > 0)
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
