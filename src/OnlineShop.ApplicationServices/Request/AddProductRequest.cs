using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.ApplicationServices.Request
{
    public class AddProductRequest
    {
        public required string Name { get; init; }
        public required ShippingType ShippingType { get; init; }
        public required PackagingType PackagingType { get; init; }
        public required decimal Price { get; init; }
    }
}
