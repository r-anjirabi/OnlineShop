namespace OnlineShop.ApplicationServices.Request
{
    public class ShipRequest
    {
        public required long OrderId { get; init; }
        public required string ShipCode { get; init; }
    }
}
