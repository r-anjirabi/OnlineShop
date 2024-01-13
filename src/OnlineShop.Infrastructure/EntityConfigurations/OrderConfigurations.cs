using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.OrderAggregate;

namespace OnlineShop.Infrastructure.EntityConfigurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseHiLo();

            var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems));

            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            orderConfiguration.Property(o => o.OrderDate).IsRequired();

            orderConfiguration.Property(o => o.Address).IsRequired();

            orderConfiguration.Property(o => o.Profit).IsRequired();

            orderConfiguration.Property(o => o.Total).IsRequired();

            orderConfiguration.Property(o => o.PayableAmount).IsRequired();

            orderConfiguration.Property(o => o.ShippedCode).IsRequired(false);

            orderConfiguration.Property(o => o.PaymentCode).IsRequired(false);

            orderConfiguration.Property(o => o.PercentageDiscount).IsRequired();

            orderConfiguration.HasOne(o => o.Customer)
            .WithMany()
            .IsRequired()
            .HasForeignKey("CustomerId");

        }
    }
}
