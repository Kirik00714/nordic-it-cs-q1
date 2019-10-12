using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
            /*
			Console.WriteLine("Enter numbers");
			var numbers = new List<double>();
			double result = 0;
			
			while (true)
			{
				try
				{
					var value = Console.ReadLine();
					
					if (value.ToLower() == "stop")
					{
						break;
					}
					else
					{
						numbers.Add(double.Parse(value));
					}
				}
				catch (FormatException vl)
				{

					Console.WriteLine(vl.Message);
				}
				
				
			}
			for (int i = 0; i < numbers.Count; i++)
			{
				result += numbers[i] / numbers.Count;
			}
			Console.WriteLine(result);
			Console.ReadKey();
			*/
            /*
			var capitals = new Dictionary<string, string>
			{
				["Russia"] = "Moscow",
				["Great Britain"] = "London",
				["USA"] = "Washington",
				["China"] = "Pekin",

			};

			
			KeyValuePair <string, string > randomElement =GetRandomElement(capitals);
			while (true)
			{
				Console.WriteLine($"Enter capital {randomElement.Key}");
				var capital = Console.ReadLine();
				if (randomElement.Key == capital)
				{
					Console.WriteLine("Nice");
				}
				
				break;
				
			}
			
			Console.ReadKey();
			*/
            /*
			Console.WriteLine("Enter number:");
			Queue<double> numbers = new Queue<double>();
			while (true)
			{
				var value = Console.ReadLine();
				if (value == "run")
				{
					
					while (numbers.Count > 0)
					{
						double number = numbers.Dequeue();
						number = Math.Sqrt(number);
						Console.WriteLine(number);
					}
				}
				else if (value == "exit")
				{
					break;
				}
				else if (value != "run" || value != "exit") 
				{
					numbers.Enqueue(int.Parse(value));
				}
			}
            */

            Stack<int> dish = new Stack<int>();
            Console.WriteLine("Enter <wash> to put the plate");
            Console.WriteLine("Enter <dry> to take the plate ");
            Console.WriteLine("Enter <exit> to exit ");
            while (true)
            {
                var value = Console.ReadLine();
                if (value == "wash")
                {
                    dish.Push(1);
                     
                }
                else if (value == "dry")
                {
                    if(dish.Count > 0)
                    {
                        dish.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No plates");
                    }
                    
                }
                else if (value == "exit")
                {
                    break;
                }
                Console.WriteLine($"Plates in a pile to wipe: {dish.Count}");
            }




        }
		/*
		private static KeyValuePair<string, string> GetRandomElement(Dictionary<string, string> capitals)
		{
			var random = new Random();
			var i = 0;
			var index = random.Next(0, capitals.Count);
			foreach (var pair in capitals)
			{
				if (i == index)
				{
					return pair;
				}
				i++;
			}
			throw new IndexOutOfRangeException();
		}
		*/



	}
}
