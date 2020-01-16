using System.Collections.Generic;

namespace ConsoleApp1
{
   
    class Customer
    {
        private Customer()
        {

        }
        public Customer(string name)
        {
            
            Name = name;
            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Order> Orders { get; private set; }
    }
}
