using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var pet1 = new Pets("Bobic" , " Dog");
			
			pet1.Sex = 'M';
			pet1.DateOfBirth = new DateTime(2015, 3, 23);
			Console.WriteLine(pet1.Description);

			var pet2 = new Pets("Vasya","Cat")
			{
				
				Sex = 'F',
				DateOfBirth = new DateTime(2018, 9, 15)
			};
			Console.WriteLine("Enter <Full> for long description or <Short> for short decription");
			string str = Console.ReadLine(); ;
			pet1.Display(str);
				Console.WriteLine(pet2.Description);
			var pets = new Pets[2];
			for (int i = 0; i < pets.Length; i++)
			{
				pets[i] = new Pets(name: Console.ReadLine(),
					kind: Console.ReadLine() );
			}
			for (int i = 0; i < pets.Length; i++)
			{
				Console.WriteLine(pets[i].ShortDescription);
			}
				Console.ReadKey();
			
			}
	}
	
}
