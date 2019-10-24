using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument baseDocument = new BaseDocument("Doc.1", "#1", DateTime.Now.Date)
			{
			};

			Passport passport = new Passport("Russia", "Kirill", DateTime.Now.Date,  "237423")
			{	
			};

			baseDocument.WriteToConsole();
			passport.WriteToConsole();
			Console.ReadKey();
		}
	}
}
