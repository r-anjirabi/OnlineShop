using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using OnlineShop.Domain.Entities.Customer;

namespace OnlineShop.ApplicationServices
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public async Task AddCustomerAsync(AddCustomerRequest req)
        {
            var customer = new Customer(req.Name);
            _repo.Add(customer);

            await _repo.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _repo.GetAllAsync();
            var customerDTOList = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                customerDTOList.Add(CustomerDTO.From(customer));
            }

            return customerDTOList;
        }
    }
}
