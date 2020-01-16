using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var product = new Product(1, "Notebook", 20_000);
            //var customer = new Customer(1, "Ivan");
            //var order = new Order(1, DateTimeOffset.UtcNow, 0.12m, customer);
            //order.OrderLines.Add(new OrderLine(order, 2, product));

            using var context = new OnlineStoreContext();
            
            context.Database.EnsureCreated();

            var product = new Product("Notebook", 20_000);
            var customer = new Customer( "Ivan");
            var order = new Order( DateTimeOffset.UtcNow, 0.12m, customer);
            order.OrderLines.Add(new OrderLine(order, 2, product));
            context.Orders.Add(order);
            context.SaveChanges();

            var lastOrder = context.Orders.OrderBy(order => order.OrderDate).Last();
            Console.WriteLine($"The laster order id is {lastOrder.Id}");
            var firstOrder = context.Orders.First(order => order.Id == 1);
            Console.WriteLine($"The first order date is {firstOrder.OrderDate}");
            var customerOrders = context.Orders.Where(order => order.Customer.Id == 1).ToList();
            Console.WriteLine($"Count of orders of customer with id 1{customerOrders.Count}");
            var customers = context.Customers.ToList();
            Console.WriteLine($"The customers count: {customers.Count}");

        }
    }
}
