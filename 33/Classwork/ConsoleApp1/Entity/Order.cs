﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Order
    {
        private Order()
        {

        }
        public Order( DateTimeOffset orderDate, decimal? discount, Customer customer)
        {
            
            OrderDate = orderDate;
            Discount = discount;
            Customer = customer;
            OrderLines = new List<OrderLine>();
            
        }

        public int Id { get;private set; }
        public DateTimeOffset OrderDate { get;private set; }
        public decimal? Discount { get;private set; }
        public Customer Customer { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public decimal TotalSum()
        {
            var sum = 0.0m;
            foreach (var line in OrderLines)
            {
                sum += line.Sum();
            }
            return sum *(1 - (Discount.GetValueOrDefault()));
        }
    }
}
