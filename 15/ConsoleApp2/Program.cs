using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			
			var cir = new Circle(1.5);
			Console.WriteLine($"Perimeter is { cir.Calculate(P)}");
			Console.WriteLine($"Square is {cir.Calculate(S)}");
			Console.ReadKey();
		}

		static double S(double radius)
		{
			double Area = Math.PI * Math.Pow(radius,2);
			return Area;
		}

		static double P(double radius)
		{
			double Per = 2 * Math.PI * radius;
			return Per;
		}
	}
}
