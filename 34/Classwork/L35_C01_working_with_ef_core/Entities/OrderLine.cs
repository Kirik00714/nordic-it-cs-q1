namespace L35_C01_working_with_ef_core.Entities
{
	public class OrderLine
	{
		public int Count { get; private set; }
		public Order Order { get; private set; }
		public Product Product { get; private set; }

		private OrderLine()
		{
		}

		public OrderLine(Order order, Product product, int count)
		{
			Order = order;
			Product = product;
			Count = count;
		}
	}
}
