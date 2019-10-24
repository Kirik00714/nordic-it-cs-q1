using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person()
			{
				Name = "Person one",
				Age = 23

			};
			Employee employee = new Employee()
			{
				Name = "Employee one",
				Age = 24,
				Company = "Company"
			};
			Console.WriteLine(person.Description);
			Console.WriteLine(employee.Description);
			Console.ReadKey();
		}
	}
}
