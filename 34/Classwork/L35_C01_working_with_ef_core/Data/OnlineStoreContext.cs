using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using L35_C01_working_with_ef_core.Entities;
using Microsoft.Extensions.Logging;

namespace L35_C01_working_with_ef_core.Data
{
	public class OnlineStoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			const string connection = "Server=tcp:shadow-art.database.windows.net,1433;" +
									  "Initial Catalog=reminder; " +
									  "Persist Security Info=False;" +
									  "User ID=app_testing@shadow-art;" +
									  "Password=XCrzJjTRqX43uzaEpJNj;" +
									  "Encrypt=True;";

			optionsBuilder
				.UseLoggerFactory(
					LoggerFactory.Create(builder => builder.AddConsole()))
				.EnableSensitiveDataLogging()
				.UseSqlServer(connection);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			OnModelCreating(modelBuilder.Entity<Product>());
			OnModelCreating(modelBuilder.Entity<Customer>());
			OnModelCreating(modelBuilder.Entity<Order>());
			OnModelCreating(modelBuilder.Entity<OrderLine>());
		}

		private static void OnModelCreating(EntityTypeBuilder<Product> builder)
		{
			builder.Property(_ => _.Id).ValueGeneratedOnAdd();
			builder.Property(_ => _.Name).IsRequired();
			builder.Property(_ => _.Price);
			builder.HasKey(_ => _.Id);
		}

		private static void OnModelCreating(EntityTypeBuilder<Customer> builder)
		{
			builder.Property(_ => _.Id).ValueGeneratedOnAdd();
			builder.Property(_ => _.Firstname).IsRequired();
			builder.Property(_ => _.Lastname);
			builder.HasKey(_ => _.Id);
		}

		private static void OnModelCreating(EntityTypeBuilder<Order> builder)
		{
			builder.Property(_ => _.Id).ValueGeneratedOnAdd();
			builder.Property(_ => _.Discount);
			builder.Property(_ => _.Total);
			builder.Property(_ => _.OrderDate);
			builder.HasKey(_ => _.Id);
			builder.HasOne(_ => _.Customer).WithMany(_ => _.Orders).OnDelete(DeleteBehavior.Cascade);
		}

		private static void OnModelCreating(EntityTypeBuilder<OrderLine> builder)
		{
			builder.Property(_ => _.Count);
			builder.HasKey($"{nameof(OrderLine.Order)}Id", $"{nameof(OrderLine.Product)}Id").IsClustered();
			builder.HasOne(_ => _.Product).WithMany(_ => _.OrderLines).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(_ => _.Order).WithMany(_ => _.OrderLines).OnDelete(DeleteBehavior.Cascade);
		}
	}
}