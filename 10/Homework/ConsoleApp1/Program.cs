using System;

namespace ConsoleApp1
{
    class Human
    {

        public string Name;
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Value must be positive");
                    }
                    age = value;
                }
                catch (ArgumentException age)
                {
                    Console.WriteLine(age.Message);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Human[] name = new Human[3];
            for (int i = 0; i < name.Length; i++)
            {
                Console.Write($" {i + 1}. Name:");

                name[i] = new Human
                {
                    Name = Console.ReadLine()
                };
            }
            Human[] age = new Human[3];
            for (int i = 0; i < age.Length; i++)
            {
                Console.Write($" {i + 1}. Age:");
                age[i] = new Human
                {
                    Age = int.Parse(Console.ReadLine())
                };    
            }
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine($"Name: {name[i].Name}, age in 4 years: {age[i].Age + 4 }");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }
    }

            

        
       
        
    
}
