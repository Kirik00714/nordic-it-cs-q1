using System;

namespace ConsoleApp1
{

	class Program
	{

		static void Main(string[] args)
		{
			Pet pet1 = new Pet();
			pet1.Name = "The Cat";
			pet1.Kind = "Cat";
			pet1.Sex = 'F';
			pet1.Age = 10;

			Pet pet2 = new Pet()
			{
				Name = "The Dog",
				Kind = "Dogt",
				Sex = 'M',
				Age = 10,
			};

			Console.WriteLine(pet1.GetDescription);
			Console.WriteLine(pet2.GetDescription);

			
			
			Console.WriteLine($"The pet kind of {pet1.Kind}, has name {pet1.Name}, age {pet1.Age}, sex {pet1.Sex}");
			Console.WriteLine($"The pet kind of {pet2.Kind}, has name {pet2.Name}, age {pet2.Age}, sex {pet2.Sex}");
		}
	}
}
