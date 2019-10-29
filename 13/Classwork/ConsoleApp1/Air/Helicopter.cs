using System;

namespace ConsoleApp1
{

	class Helicopter : Fly , IHelicopter
	{
		public Helicopter(byte bladesCount, int maxHeight) : base(maxHeight, 0)
		{
			BladesCount = bladesCount;
			Console.WriteLine("It is a helicopter, welcome a board!");
		}

		public byte BladesCount { get; private set; }
		public void AllProperies()
		{
			
			Console.WriteLine($"BladesCount: {BladesCount}");
			Console.WriteLine($"CurrentHeight: {0}");
			Console.WriteLine($"MaxHeight: {MaxHeight}");
		}

	}
}
