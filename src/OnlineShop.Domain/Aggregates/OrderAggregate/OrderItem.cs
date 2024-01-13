using OnlineShop.Domain.Base;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Domain.Aggregates.OrderAggregate
{
    internal class OrderItem : Entity
    {
        public Product Product { get; private set; }
        public long ProductId { get; private set; }
        public int Units { get; private set; }
        public decimal UnitPrice { get; private set; }

        public OrderItem(long productId, decimal unitPrice, int units = 1)
        {
            ProductId = productId;
            Units = units;
            UnitPrice = unitPrice;
        }
    }
}
