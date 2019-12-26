using System;

namespace ConsoleApp1
{
    class Program
    {
        private const string ConnectionString = "Server=tcp:shadow-art.database.windows.net,1433,Initial Catalog=reminder; Persist Security Info=False;User ID=app_user@shadow-art;Password=XCrzJjTRqX43uzaEpJNj;Encrypt=True;";
        private static void Main(string[] args)
        {
            var productRepository = new ProductRepository(ConnectionString);
            var productCount = productRepository.GetCount();
            Console.WriteLine($"Count from PRODUCT table:{productCount}");

         

            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"Product with id {product.Id} has name {product.Name} with price {product.Price}");
            }

            var productId = productRepository.Insert("Phone", 20000);
            Console.WriteLine($"Inserd product id: {productId}");

            var orderRepository = new OrderRepository(ConnectionString);
            var command = new CreateOrderCommand(
                customerId: 4,
                orderDate: DateTimeOffset.Now,
                discount: 0,
                new CreateOrderCommand.Line(3, 4),
                new CreateOrderCommand.Line(7, 1),
                new CreateOrderCommand.Line(29, 1));
            var orderId = orderRepository.Insert(command);
            Console.WriteLine($"Inserted order id{orderId}");
        }
    }
}
