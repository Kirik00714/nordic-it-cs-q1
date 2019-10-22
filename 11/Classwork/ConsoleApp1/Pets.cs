using System;

namespace ConsoleApp1
{
	public class Pets
	{
		public string Kind;
		public string Name;
		public char Sex;
		public DateTime DateOfBirth;
		public Pets(string name, string kind)
		{
			Name = name;
			Kind = kind;
		}
		
		public byte GetAge()
		{
			var date = DateTime.Now;
			TimeSpan different = date - DateOfBirth;
			return (byte) Math.Floor(different.TotalDays / 365);
		}
		public string Description
		{
			get { return $"The pet kind of { Kind}, has name { Name}, age { GetAge()}, sex { Sex} "; }
		}
		public string ShortDescription
		{
			get { return $"The pet kind of { Kind}, has name { Name}"; }
		}
		public void Display(string str)
		{
			
			if (str == "Full")
			{
				Console.WriteLine(Description);
			}
			else if (str == "Short")
			{
				Console.WriteLine(ShortDescription);
			}
		}
			
	}
}
