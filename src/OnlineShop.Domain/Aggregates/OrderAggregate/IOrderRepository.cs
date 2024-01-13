using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Aggregates.OrderAggregate
{
    internal interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);

        Task<Order> GetAsync(long orderId);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
