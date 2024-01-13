using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;

namespace OnlineShop.ApplicationServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(AddCustomerRequest req);
        Task<List<CustomerDTO>> GetAllCustomersAsync();
    }
}
