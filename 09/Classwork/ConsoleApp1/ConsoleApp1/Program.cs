using System;
using System.Diagnostics;
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch time = new Stopwatch();
			var arr = new int[50000];
			var rnd = new Random();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next();
			}
			
				time.Start();
			BubleSort(arr);
			time.Stop();
				Console.WriteLine($" Time1: {time.ElapsedMilliseconds}");
				time.Reset();
				time.Start();
				Array.Sort(arr, (x, y) => x.CompareTo(y));
				time.Stop();
				Console.WriteLine($" Time2: {time.ElapsedMilliseconds}");
				Console.ReadKey();
			}
			
			static void BubleSort(int[] arr)
			{
				for (int i = 0; i < arr.Length - 1; i++)
				{
					var limit = arr.Length - 1 - i;
					for (int j = 0; j < limit; j++)
					{
						if (arr[j]> arr[j+1])
						{
							var temp = arr[j +1];
							arr[j + 1] = arr[j];
							arr[j]  = temp;
						}
					}

				}


			}
			
		}
}
