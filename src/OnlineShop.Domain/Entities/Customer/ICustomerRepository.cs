using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Entities.Customer
{
    internal interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer order);

        Task<Customer> GetAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
