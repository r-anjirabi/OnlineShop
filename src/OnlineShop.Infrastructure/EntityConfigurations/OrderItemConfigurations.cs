using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.OrderAggregate;

namespace OnlineShop.Infrastructure.EntityConfigurations
{
    internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
        {
            orderItemConfiguration.HasKey(o => o.Id);
            orderItemConfiguration.Property(o => o.Id).UseHiLo();

            orderItemConfiguration.Property(o => o.UnitPrice).IsRequired();
            orderItemConfiguration.Property(o => o.Units).IsRequired();

            orderItemConfiguration.HasOne(o => o.Product)
            .WithMany()
            .IsRequired()
            .HasForeignKey("ProductId");

        }
    }
}
