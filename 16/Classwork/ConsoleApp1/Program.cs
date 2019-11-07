using System;

namespace ConsoleApp1
{
	
	public sealed class Circle
	{
		private  double radius;

		public Circle(double radius)
		{
			this.radius = radius;
		}
		public double Calculate(Func<double, double> operation)
		{
			return operation(radius);
		}
		
	}
	class Program
	{
		static void Main(string[] args)
		{
			var cir = new Circle(1.5);
			Console.WriteLine($"Perimeter is { cir.Calculate(radius => 2 * Math.PI * radius )}");
			Console.WriteLine($"Square is {cir.Calculate(radius => Math.PI * Math.Pow(radius, 2))}");
			Console.WriteLine($"Diametr is {cir.Calculate(radius => radius * 2)}");
			Console.ReadKey();
			
		}
		
	}
}
