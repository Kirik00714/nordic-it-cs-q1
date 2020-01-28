using System.Collections.Generic;

namespace L35_C01_working_with_ef_core.Entities
{
	public class Product
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; set; }
		public ICollection<OrderLine> OrderLines { get; private set; }

		private Product()
		{
			OrderLines = new HashSet<OrderLine>();
		}

		public Product(string name, decimal price) : this()
		{
			Name = name;
			Price = price;
		}
	}
}
