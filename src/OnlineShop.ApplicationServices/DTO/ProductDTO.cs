using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.ApplicationServices.DTO
{
    public class ProductDTO
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public ShippingType ShippingType { get; init; }
        public PackagingType PackagingType { get; init; }
        public decimal Price { get; init; }

        internal static ProductDTO From(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                PackagingType = product.PackagingType,
                Price = product.Price,
                ShippingType = product.ShippingType,
            };
        }
    }
}
