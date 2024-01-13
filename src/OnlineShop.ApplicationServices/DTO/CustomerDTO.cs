using OnlineShop.Domain.Entities.Customer;

namespace OnlineShop.ApplicationServices.DTO
{
    public class CustomerDTO
    {
        public long Id { get; init; }
        public string Name { get; init; }

        internal static CustomerDTO From(Customer customer)
        {
            return new CustomerDTO { Id = customer.Id, Name = customer.Name };
        }
    }
}
