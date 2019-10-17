using System;

namespace ConsoleApp1
{
	class Pet
	{
		public string Kind;
		public string Name;
		public char Sex;
		public int Age;

		/*
		public string GetDescription 
		{
			get
			{
				return $"The pet kind of {Kind}, has name {Name}, age {Age}, sex {Sex}";
			}
		}
		*/
		public string GetDescription =>
			 $"The pet kind of {Kind}, has name {Name}, age {Age}, sex {Sex}";
		
	}
}
