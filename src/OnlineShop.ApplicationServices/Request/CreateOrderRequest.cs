namespace OnlineShop.ApplicationServices.Request
{
    public class CreateOrderRequest
    {
        public required long CustomerId { get; init; }
        public required string Address { get; init; }
        public int PercentageDiscount { get; init; }
        public decimal ConstantProfit { get; init; }
        public required List<CreateOrderItemDTO> OrderItems { get; init; }

    }
}
