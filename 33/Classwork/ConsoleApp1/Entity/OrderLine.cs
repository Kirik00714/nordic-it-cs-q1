namespace ConsoleApp1
{
    class OrderLine
    {
        private OrderLine()
        {

        }
        public OrderLine(Order order, int count, Product product)
        {
            Order = order;
            Count = count;
            Product = product;

        }

        public int Count { get; private set; }
        public Product  Product { get; private set; }
        public Order Order { get;private set; }

        public decimal Sum()
        {
            return Product.Price * Count;
        }
    }
}
