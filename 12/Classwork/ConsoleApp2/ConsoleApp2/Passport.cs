using System;

namespace ConsoleApp2
{
	class Passport : BaseDocument
	{
		public string Country { get; set; }
		public string PersonName { get; set; }
		public new string Description
		{
			get
			{
				return $"{base.Description}, country {Country}, name is {PersonName}";
			}
		}
		public new void WriteToConsole()
		{
			Console.WriteLine(Description);
		}
	}
}
