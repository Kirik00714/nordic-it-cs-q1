using System.Collections.Generic;

namespace ConsoleApp1
{
    class Product
    {
        private Product()
        {

        }
        public Product( string name, decimal price)
        {
            
            Name = name;
            Price = price;
            OrderLines = new List<OrderLine>();

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public ICollection<OrderLine> OrderLines { get; private set; }


    }
}
