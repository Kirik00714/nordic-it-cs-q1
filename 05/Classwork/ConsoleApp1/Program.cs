using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			Console.WriteLine("Enter number");
			var x = int.Parse(Console.ReadLine());
			var message = (x > 100 && x < 1000)
				? "Nice"
				: "Bad";
			Console.WriteLine( message);
			Console.ReadKey();
			*/
			Console.WriteLine("Enter number 0..99");
			var number = int.Parse(Console.ReadLine());
			var firstDigital = number / 10;
			var lastDigital = number % 10;
			switch (lastDigital)
			{
				case 1 when firstDigital > 1 || firstDigital == 0:
					Console.WriteLine($"{number} : {number}  год");
					break;
				case 2 when firstDigital > 1 || firstDigital == 0:
				case 3 when firstDigital > 1 || firstDigital == 0:
				case 4 when firstDigital > 1 || firstDigital == 0:
					Console.WriteLine($"{number} : {number}  года");
					break;
				default:
					Console.WriteLine($"{number} : {number}  лет");
					break;
			}
			Console.ReadKey();
		}
	}
}
