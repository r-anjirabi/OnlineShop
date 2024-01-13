namespace OnlineShop.ApplicationServices.Request
{
    public class CreateOrderItemDTO
    {
        public required long ProductId { get; init; }
        public required int Units { get; init; }
    }
}
