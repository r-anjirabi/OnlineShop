using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Base;
using OnlineShop.Domain.Entities.Customer;

namespace OnlineShop.Infrastructure.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly OrderingContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(OrderingContext orderingContext)
        {
            _context = orderingContext;
        }

        public Customer Add(Customer customer)
        {
            return _context.Customers.Add(customer).Entity;
        }

        public async Task<Customer> GetAsync(int customerId)
        {
            var customer = await _context
                    .Customers
                    .SingleOrDefaultAsync(o => o.Id == customerId);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _context
                .Customers
                .ToArrayAsync();

            return customers;
        }
    }
}
