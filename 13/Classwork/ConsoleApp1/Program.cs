using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var plane = new Plane(5, 3000);
			plane.TakeLover(0);
			plane.TakeUpper(3000);
			plane.AllProperies();
			var helicopter = new Helicopter(4, 750);
			helicopter.TakeUpper(500);
			helicopter.TakeLover(0);
			helicopter.AllProperies();
			Console.ReadKey();
		}
	}
}
