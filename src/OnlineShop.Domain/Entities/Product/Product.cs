using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Entities.Product
{
    internal class Product : Entity
    {
        public string Name { get; private set; }
        public ShippingType ShippingType { get; private set; }
        public PackagingType PackagingType { get; private set; }
        public decimal Price { get; private set; }


        public Product(string name, PackagingType packagingType, decimal price)
        {
            Name = name;
            ShippingType = packagingType == PackagingType.Regular ? ShippingType.Regular : ShippingType.Express;
            PackagingType = packagingType;
            Price = price;
        }

    }
}
