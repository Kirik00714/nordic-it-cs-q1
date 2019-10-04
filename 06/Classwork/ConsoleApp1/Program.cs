using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			Console.WriteLine("Please enter string  ");
			string str;
			do
			{
				str = Console.ReadLine();
				if (str.Length <= 15)
				{
					Console.WriteLine($"Entered string length is {str.Length}");
					
				}
				else
				{
					Console.WriteLine("Too long string.Tru another..");
					continue;
				}
				
			}
			while (true);
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
			


			int[] num = new int[7] { 1, 2, 3, 4, 5, 6, 7} ;
			int i = 0;
			int sum = 0;
			while (i < num.Length)
			{
				sum += num[i];
				i++;
			}
			Console.WriteLine($"Sum = {sum}");
			Console.ReadKey();
			*/

			var marks = new[]
			{
				new [] { 2, 3, 3, 2, 3},
				new [] { 2, 4, 3, 5},
				null,
				new [] { 5, 5, 5, 5},
				new [] { 4}
			};
			double sum = 0;
			double sumweek = 0;
			for (int i = 0; i < marks.Length; i++)
			{
                if (marks[i] != null)
                {

                    sum = 0;
                    for (int j = 0; j < marks[i].Length; j++)
                    {
                        sum += marks[i][j];

                    }
                    sum /= marks[i].Length;
                    sumweek += sum;
                }


                else
                {

                    Console.WriteLine("N/A");
                }

				
				Console.WriteLine($"The averange mark for day #{i} is {sum }");
				
			}
			sumweek /= marks.Length;
			Console.WriteLine($"The averange mark for week is {sumweek}");

			Console.ReadKey();
				
		} 
	}
}
