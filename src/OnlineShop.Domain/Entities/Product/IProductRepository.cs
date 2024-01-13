using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Entities.Product
{
    internal interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(long productId);
    }
}
