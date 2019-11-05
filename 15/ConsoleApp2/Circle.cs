using System;

namespace ConsoleApp2
{
	public sealed class Circle
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
}
