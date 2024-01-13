using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Base;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly OrderingContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(OrderingContext orderingContext)
        {
            _context = orderingContext;
        }
        public async Task<Product> GetAsync(long productId)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(o => o.Id == productId);
            return product;
        }

        public Product Add(Product product)
        {
            return _context.Products.Add(product).Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context
            .Products
            .ToArrayAsync();

            return products;
        }
    }
}
