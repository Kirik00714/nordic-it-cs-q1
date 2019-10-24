namespace ConsoleApp1
{
	class Person
	{
		public string Name { get; set; }

		public byte Age { get; set; }
		public string Description
		{
			get
			{
				return $"Name is {Name}, age is {Age}";
			}
			
		}
	}
}
