using System;
using Calculator.Figure;

namespace Caculator.Operation
{
	public class CircleOperation
	{
		public static double Perimeter(double radius)
		{
			return 2 * Math.PI * radius;
		}
		public static  double Square(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
	
	public  class SquareOperation
	{
		public static double Perimeter(double side)
		{
			return 4*side;
		}
		public static double Square(double side)
		{
			return side*side;
		}
	}
}
