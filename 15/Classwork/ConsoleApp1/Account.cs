using System;

namespace ConsoleApp1
{
	class Account<T>
	{
		public Account(T id, string name)
		{
			Id = id;
			Name = name;
		}

		public T Id { get; private set; }
		public string Name { get; private set; }
		public void WriteProperties() => 
			Console.WriteLine($"Id:{Id}, Name:{Name}");

	}
}
