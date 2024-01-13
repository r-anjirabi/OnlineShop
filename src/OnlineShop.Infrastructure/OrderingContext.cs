using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.OrderAggregate;
using OnlineShop.Domain.Base;
using OnlineShop.Domain.Entities.Customer;
using OnlineShop.Domain.Entities.Product;
using OnlineShop.Infrastructure.EntityConfigurations;

namespace OnlineShop.Infrastructure
{
    internal class OrderingContext : DbContext, IUnitOfWork
    {
        public OrderingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
        }
    }
}
