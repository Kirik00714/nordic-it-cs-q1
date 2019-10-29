using System;

namespace ConsoleApp1
{
	class Plane : Fly, IPlane
	{
		public Plane(byte enginesCount,int maxHeight) : base (maxHeight, 0)
		{
			EnginesCount = enginesCount;
			Console.WriteLine("It is a plane, welcome a board!");
		}

		public byte EnginesCount { get; private set; }
		public void AllProperies()
		{
			
			Console.WriteLine($"BladesCount: {EnginesCount}");
			Console.WriteLine($"CurrentHeight: {0}");
			Console.WriteLine($"MaxHeight: {MaxHeight}");
		}

	}
}
