using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class OnlineStoreContext : DbContext
    {
        private const string ConnectionString = "Server=tcp:shadow-art.database.windows.net,1433;Initial Catalog=reminder;Persist Security Info=False;User ID=k_balaev;Password=9tf1qE9gKDje4TJA7z8K;Encrypt=True;";
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnEntityModelCreating(modelBuilder.Entity<Customer>());
            OnEntityModelCreating(modelBuilder.Entity<Product>());
            OnEntityModelCreating(modelBuilder.Entity<Order>());
            OnEntityModelCreating(modelBuilder.Entity<OrderLine>());
        }

        private void OnEntityModelCreating(EntityTypeBuilder<Customer> builder)
        {
            //builder.Property(nameof(Customer.Id));
            //builder.Property(nameof(Customer.Name));

            builder.Property(customer => customer.Id).ValueGeneratedOnAdd();
            builder.Property(customer => customer.Name).HasMaxLength(128);
        
        }
        private void OnEntityModelCreating(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Id).ValueGeneratedOnAdd();
            builder.Property(product => product.Name).HasMaxLength(512);
            builder.Property(product => product.Price);
        }
        private void OnEntityModelCreating(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(new[] { "ProductId", "OrderId" });
            builder.Property(line => line.Count);
            builder.HasOne(line => line.Order).WithMany(order => order.OrderLines);
            builder.HasOne(line => line.Product).WithMany(product => product.OrderLines);

        }
        private void OnEntityModelCreating(EntityTypeBuilder<Order> builder)
        {
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
            builder.Property(order => order.OrderDate);
            builder.Property(order => order.Discount);
            builder.HasOne(order => order.Customer).WithMany(customer => customer.Orders);
        }
    }
}
