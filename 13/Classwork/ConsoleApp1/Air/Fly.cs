using System;

namespace ConsoleApp1
{
	abstract class Fly : IFly
	{
		protected Fly(int maxHeight, int currenHeight)
		{
			MaxHeight = maxHeight;
			CurrenHeight = currenHeight;
		}

		public int MaxHeight { get; private set; }
		public int CurrenHeight { get; private set; }
		public void TakeUpper(int delta)
		{

			if (delta < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (CurrenHeight - delta > MaxHeight)
			{
				MaxHeight = MaxHeight;
			}
			else
				CurrenHeight += delta;
		}
		public void TakeLover(int delta)
		{
			if (delta < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (CurrenHeight - delta > 0)
			{
				CurrenHeight = CurrenHeight - delta;
			}
			if (CurrenHeight - delta == 0)
			{
				CurrenHeight = 0;
			}
			if (CurrenHeight - delta < 0)
			{
				throw new InvalidOperationException("Crash");
			}
		}
	}
}
