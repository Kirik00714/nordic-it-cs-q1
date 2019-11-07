using System;

namespace Calculator.Figure
{
	public class Circle
	{
		private double radius;

		public Circle(double radius)
		{
			this.radius = radius;
		}
		public double Calculate(Func<double, double> operation)
		{
			return operation(radius);
		}
	}
	public class Square
	{
		private double side;

		public Square(double side)
		{
			this.side = side;
		}
		public double Calculate(Func<double, double> operation)
		{
			return operation(side);
		}
	}
}
