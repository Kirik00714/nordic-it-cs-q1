using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    class OnlineStoreContext : DbContext
    {
        private const string ConnectionString =
           "Server=tcp:shadow-art.database.windows.net,1433;" +
           "Initial Catalog=reminder;" +
           "Persist Security Info=False;" +
           "User ID=k_balaev;" +
           "Password=9tf1qE9gKDje4TJA7z8K;" +
           "Encrypt=True;";

        public DbSet<Address> Addresss { get; set; }
        public DbSet<DocumentStatus> DocumentStatuss { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<City> Citys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnEntityModelCreating(modelBuilder.Entity<Address>());
            OnEntityModelCreating(modelBuilder.Entity<DocumentStatus>());
            OnEntityModelCreating(modelBuilder.Entity<Document>());
            OnEntityModelCreating(modelBuilder.Entity<Contractor>());
            OnEntityModelCreating(modelBuilder.Entity<Position>());
            OnEntityModelCreating(modelBuilder.Entity<City>());

        }

        private void OnEntityModelCreating(EntityTypeBuilder<Address> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(_ => _.CityName).WithMany(_ => _.Addresss);
            entityTypeBuilder.Property(_ => _.AddressName).HasMaxLength(128);
            
        }
        private void OnEntityModelCreating(EntityTypeBuilder<DocumentStatus> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(_ => _.Status).HasMaxLength(128);
            entityTypeBuilder
                .HasOne(_ => _.Sender)
                .WithMany(_ => _.DocumentsSender);
            entityTypeBuilder
                .HasOne(_ => _.Receiver)
                .WithMany(_ => _.DocumentsReceiver);
            entityTypeBuilder
                .HasOne(_ => _.Document)
                .WithMany(_ => _.Documents);
            entityTypeBuilder.Property(_ => _.DateTime);


        }
        private void OnEntityModelCreating(EntityTypeBuilder<Document> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(_ => _.Pages);
            entityTypeBuilder.Property(_ => _.Name).HasMaxLength(256);
            entityTypeBuilder.Property(_ => _.Type).HasMaxLength(128);
        }
        private void OnEntityModelCreating(EntityTypeBuilder<Contractor> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(_ => _.Name).HasMaxLength(128);
            entityTypeBuilder.HasOne(_ => _.PositionName).WithMany(_ => _.Contractors);
            entityTypeBuilder
                .HasOne(_ => _.AddressName)
                .WithMany(_ => _.Contractors);
        }
        private void OnEntityModelCreating(EntityTypeBuilder<Position> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(_ => _.Name).HasMaxLength(256);
        }
        private void OnEntityModelCreating(EntityTypeBuilder<City> entityTypeBuilder)
        {
            entityTypeBuilder.Property(_ => _.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(_ => _.Name).HasMaxLength(256);
        }
    }
}
