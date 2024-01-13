using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.OrderAggregate;
using OnlineShop.Domain.Base;

namespace OnlineShop.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public OrderRepository(OrderingContext orderingContext)
        {
            _context = orderingContext;
        }
        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task<Order> GetAsync(long orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context
                .Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .Include(o => o.Customer)
                .ToArrayAsync();

            return orders;
        }
    }
}
