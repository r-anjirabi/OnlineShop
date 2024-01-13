using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using OnlineShop.ApplicationServices.Setting;
using OnlineShop.Domain;
using OnlineShop.Domain.Aggregates.OrderAggregate;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.ApplicationServices
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IOrderSetting _orderSetting;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository repo, IOrderSetting orderSetting, IProductRepository productRepo)
        {
            _repo = repo;
            _orderSetting = orderSetting;
            _productRepo = productRepo;
        }
        public async Task CreateOrderAsync(CreateOrderRequest req)
        {
            if (DateTime.Now.Hour < _orderSetting.OrderingStartHour || DateTime.Now.Hour > _orderSetting.OrderingEndHour)
            {
                throw new DomainException($"Order time must be wbetween {_orderSetting.OrderingStartHour} AM and {_orderSetting.OrderingEndHour} PM");
            }

            var order = new Order(req.CustomerId, req.Address, req.PercentageDiscount, req.ConstantProfit);
            foreach (var item in req.OrderItems)
            {
                var product = await _productRepo.GetAsync(item.ProductId);
                order.AddOrderItem(item.ProductId, product.Price, item.Units);
            }

            if (order.PayableAmount < _orderSetting.MinimumOrderPrice)
            {
                throw new DomainException($"Minimum order price is {_orderSetting.MinimumOrderPrice}. your total price is {order.PayableAmount}.");
            }

            _repo.Add(order);

            await _repo.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _repo.GetAllAsync();

            var orderDTOList = new List<OrderDTO>();
            foreach (var item in orders)
            {
                orderDTOList.Add(OrderDTO.From(item));
            }

            return orderDTOList;
        }

        public async Task PaymentAsync(PaymentRequest paymentRequest)
        {
            var order = await _repo.GetAsync(paymentRequest.OrderId);
            order.SetPaidStatus(paymentRequest.PaymentCode);

            await _repo.UnitOfWork.SaveChangesAsync();
        }

        public async Task ShipAsync(ShipRequest shipRequest)
        {
            var order = await _repo.GetAsync(shipRequest.OrderId);
            order.SetShipped(shipRequest.ShipCode);

            await _repo.UnitOfWork.SaveChangesAsync();
        }
    }
}
