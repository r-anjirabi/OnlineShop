using OnlineShop.Domain.Aggregates.OrderAggregate;

namespace OnlineShop.ApplicationServices.DTO
{
    public class OrderDTO
    {
        public long Id { get; init; }
        public CustomerDTO Customer { get; init; }
        public DateTime OrderDate { get; init; }
        public string Address { get; init; }
        public OrderStatus OrderStatus { get; init; }
        public List<OrderItemDTO> OrderItems { get; init; } = [];
        public int PercentageDiscount { get; init; }
        public decimal Total { get; init; }
        public decimal PayableAmount { get; init; }
        public decimal Profit { get; init; }
        public string PaymentCode { get; init; }
        public string ShippedCode { get; init; }

        internal static OrderDTO From(Order order)
        {
            var orderDTO = new OrderDTO
            {
                Address = order.Address,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                Customer = new CustomerDTO() { Name = order.Customer.Name, Id = order.Customer.Id },
                Id = order.Id,
                PercentageDiscount = order.PercentageDiscount,
                PayableAmount = order.PayableAmount,
                Profit = order.Profit,
                PaymentCode = order.PaymentCode,
                ShippedCode = order.ShippedCode,
                Total = order.Total
            };

            foreach (var item in order.OrderItems)
            {
                orderDTO.OrderItems.Add(OrderItemDTO.From(item));
            }

            return orderDTO;
        }
    }
}
