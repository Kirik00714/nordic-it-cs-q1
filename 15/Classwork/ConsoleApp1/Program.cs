using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var Acc = new Account<int>(2,"Andrey");
			Acc.WriteProperties();
			var Acc1 = new Account<string>("32","Sasha");
			Acc1.WriteProperties();
			Guid.NewGuid();
			var Acc2 = new Account<Guid>(Guid.NewGuid(),"Nikita");
			Acc2.WriteProperties();
			Console.ReadKey();

		}
	}
}
