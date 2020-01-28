using L35_C01_working_with_ef_core.Data;
using L35_C01_working_with_ef_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace L35_C01_working_with_ef_core
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			MigrateDatabase();

			var products = new[]
			{
				new Product("Notebook", 20_000m),
				new Product("Phone", 20_000m),
			};
			var customer = new Customer("Ivan", "Ivanov");
			var order = new Order(customer, 0.17m);

			foreach (var product in products)
			{
				order.AddLine(product, 1);
			}

			SaveOrder(order);
		}

		private static void SaveOrder(Order order)
		{
			order.CalculateTotal();

			using var context = new OnlineStoreContext();
			context.Orders.Add(order);
			context.SaveChanges();
		}

		private static void MigrateDatabase()
		{
			using var context = new OnlineStoreContext();
			context.Database.Migrate();
		}
	}
}