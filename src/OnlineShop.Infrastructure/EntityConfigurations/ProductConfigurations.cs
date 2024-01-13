using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Infrastructure.EntityConfigurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> productConfiguration)
        {
            productConfiguration.HasKey(o => o.Id);
            productConfiguration.Property(o => o.Id).UseHiLo();

            productConfiguration.Property(o => o.Name).IsRequired();
            productConfiguration.Property(o => o.PackagingType).IsRequired();
            productConfiguration.Property(o => o.ShippingType).IsRequired();
            productConfiguration.Property(o => o.Price).IsRequired();

        }
    }
}
