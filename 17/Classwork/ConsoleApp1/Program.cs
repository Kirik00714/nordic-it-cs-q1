using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var generator = new RandomDataGenerator();
			generator.RandomDataGenerating += OnRandomDataGenerating;
			generator.RandomDataGenerated += OnRandomDataGenerated;
			var data = generator.GetRandomData(8, 3);
			
			Console.ReadKey();

		}

		private static void OnRandomDataGenerated(object sender, EventArgs e)
		{
			Console.WriteLine("data generated");
		}

		private static void OnRandomDataGenerating(object generator, RDG e)
		{
			Console.WriteLine($"Generate {e.DS} data of {e.bDTRE}");
		}
	}
}
