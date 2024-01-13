namespace OnlineShop.ApplicationServices.Request
{
    public class PaymentRequest
    {
        public required long OrderId { get; init; }
        public required string PaymentCode { get; init; }
    }
}
