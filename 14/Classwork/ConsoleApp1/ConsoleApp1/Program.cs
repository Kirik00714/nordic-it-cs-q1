using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var errorlist = new ErrorList("Number", new List<string>()))
			{
				errorlist.Add("1");
				errorlist.Add("2");
				foreach (var item in errorlist )
				{
					Console.WriteLine($"Category:{errorlist.Category},Error:{item}");
				}
				Console.ReadKey();
			}

		}
	}
}
