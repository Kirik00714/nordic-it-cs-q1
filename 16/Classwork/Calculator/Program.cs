using System;
using Calculator.Figure;
using Caculator.Operation;

namespace Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			var cir = new Circle(1.5);
			Console.WriteLine(cir.Calculate(CircleOperation.Perimeter));
			Console.WriteLine(cir.Calculate(CircleOperation.Square));
			var squ = new Square(2);
			Console.WriteLine(squ.Calculate(SquareOperation.Perimeter));
			Console.WriteLine(squ.Calculate(SquareOperation.Square));
			Console.ReadKey();
		}
	}
}
