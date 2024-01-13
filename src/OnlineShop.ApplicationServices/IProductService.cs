using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;

namespace OnlineShop.ApplicationServices
{
    public interface IProductService
    {
        Task AddProductAsync(AddProductRequest req);
        Task<List<ProductDTO>> GetAllProductsAsync();
    }
}
