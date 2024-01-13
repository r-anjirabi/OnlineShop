using OnlineShop.Domain.Aggregates.OrderAggregate;

namespace OnlineShop.ApplicationServices.DTO
{
    public class OrderItemDTO
    {
        public long Id { get; init; }
        public ProductDTO Product { get; init; }
        public int Units { get; init; }
        public decimal UnitPrice { get; init; }

        internal static OrderItemDTO From(OrderItem item)
        {
            return new OrderItemDTO()
            {
                Id = item.Id,
                UnitPrice = item.UnitPrice,
                Units = item.Units,
                Product = ProductDTO.From(item.Product)
            };
        }
    }
}
