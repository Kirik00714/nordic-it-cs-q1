using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CityApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			BuilderWebHostBuilder(args)
				.Build()
				.Run();
			Console.ReadKey();
		}
		static IWebHostBuilder BuilderWebHostBuilder (string[] args)
		{
			return WebHost.CreateDefaultBuilder().UseStartup<Startup>();
		}
	}
}
