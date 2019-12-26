using System;

namespace ConsoleApp1
{
    public class CreateOrderCommand
    {
        public CreateOrderCommand(int customerId, DateTimeOffset orderDate, decimal discount, params Line[] lines)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            Discount = discount;
            Lines = lines;
        }

        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Discount { get; set; }
        public Line[] Lines { get; set; }

        public class Line
        {
            public Line(int productId, int count)
            {
                ProductId = productId;
                Count = count;
            }

            public int ProductId { get; set; }
            public int Count { get; set; }
        }
    }
}
