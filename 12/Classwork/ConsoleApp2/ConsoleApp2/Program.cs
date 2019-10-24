using System;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument baseDocument = new BaseDocument()
			{
				Title = "Doc.1",
				Number = "#1",
				IssueDate = DateTime.Now.Date,

			};
			baseDocument.WriteToConsole();
			Passport passport = new Passport()
			{
				Title = "Doc.2",
				Number = "#2",
				IssueDate = DateTime.Now.Date,
				Country = "Russia",
				PersonName = "Kirill"
			};
			passport.WriteToConsole();
			Console.ReadKey();
		}
	}
}
