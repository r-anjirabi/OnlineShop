using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;

namespace OnlineShop.ApplicationServices
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderRequest orderRequest);
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task PaymentAsync(PaymentRequest paymentRequest);
        Task ShipAsync(ShipRequest shipRequest);
    }
}
