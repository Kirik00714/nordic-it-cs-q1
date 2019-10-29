namespace ConsoleApp1
{
	interface IFly
	{
		int MaxHeight { get;}
		int CurrenHeight { get;}
		void TakeUpper(int delta);
		void TakeLover(int delta);
	}
}
