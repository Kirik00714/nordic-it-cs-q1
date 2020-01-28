using System;
using System.Collections.Generic;
using System.Linq;

namespace L35_C01_working_with_ef_core.Entities
{
	public class Order
	{
		public int Id { get; private set; }
		public DateTimeOffset OrderDate { get; private set; }
		public decimal? Discount { get; private set; }
		public decimal Total { get; private set; }
		public Customer Customer { get; private set; }
		public ICollection<OrderLine> OrderLines { get; private set; }

		private Order()
		{
			OrderLines = new HashSet<OrderLine>();
		}

		public Order(Customer customer, decimal? discount = null) : this()
		{
			Customer = customer;
			OrderDate = DateTimeOffset.UtcNow;
			Discount = discount;
		}

		public void AddLine(Product product, int count)
		{
			OrderLines.Add(
				new OrderLine(this, product, count)
			);
		}

		public void CalculateTotal()
		{
			Total = OrderLines.Sum(line => line.Product.Price * line.Count) *
					(1m - Discount.GetValueOrDefault());
		}
	}
}
