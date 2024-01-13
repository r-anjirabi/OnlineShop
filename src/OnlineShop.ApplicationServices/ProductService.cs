using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.ApplicationServices
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task AddProductAsync(AddProductRequest req)
        {
            var product = new Product(req.Name, req.PackagingType, req.Price);
            _repo.Add(product);

            await _repo.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _repo.GetAllAsync();
            var productDTOList = new List<ProductDTO>();
            foreach (var product in products)
            {
                productDTOList.Add(ProductDTO.From(product));
            }

            return productDTOList;
        }
    }
}
