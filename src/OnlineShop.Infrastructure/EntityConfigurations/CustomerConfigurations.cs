using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Customer;

namespace OnlineShop.Infrastructure.EntityConfigurations
{
    internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customerConfiguration)
        {
            customerConfiguration.HasKey(o => o.Id);
            customerConfiguration.Property(o => o.Id).UseHiLo();

            customerConfiguration.Property(o => o.Name).IsRequired();

        }
    }
}
