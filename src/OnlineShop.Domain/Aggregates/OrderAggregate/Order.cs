using OnlineShop.Domain.Base;
using OnlineShop.Domain.Entities.Customer;

namespace OnlineShop.Domain.Aggregates.OrderAggregate
{
    internal class Order : Entity
    {
        public Customer Customer { get; private set; }
        public long CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Address { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public int PercentageDiscount { get; private set; }
        public decimal Total { get; private set; }
        public decimal PayableAmount { get; private set; }
        public decimal Profit { get; private set; }
        public string PaymentCode { get; private set; }
        public string ShippedCode { get; private set; }

        public Order(long customerId, string address, int percentageDiscount = 0, decimal profit = 0)
        {
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            Address = address;
            OrderStatus = OrderStatus.Submitted;
            PercentageDiscount = percentageDiscount;
            Profit = profit;
        }
        public void AddOrderItem(long productId, decimal unitPrice, int units = 1)
        {
            if (OrderStatus != OrderStatus.Submitted)
            {
                throw new DomainException($"Invalid change order status. Order status is {OrderStatus}");
            }

            var orderItem = new OrderItem(productId, unitPrice, units);
            _orderItems.Add(orderItem);

            CalculatePrice();
        }

        public void SetPaidStatus(string paymentCode)
        {
            if (OrderStatus != OrderStatus.Submitted)
            {
                throw new DomainException($"Invalid change order status. Order status is {OrderStatus}");
            }

            PaymentCode = paymentCode.ToLower();
            OrderStatus = OrderStatus.Paid;
        }

        public void SetShipped(string shippedCode)
        {
            if (OrderStatus != OrderStatus.Paid)
            {
                throw new DomainException($"Invalid change order status. Order status is {OrderStatus}");
            }

            ShippedCode = shippedCode.ToLower();
            OrderStatus = OrderStatus.Shipped;
        }

        void CalculatePrice()
        {
            Total = _orderItems.Sum(o => o.Units * o.UnitPrice);

            var totalSubtractDiscount = Total - (Total * PercentageDiscount / 100.0m);

            PayableAmount = totalSubtractDiscount + Profit;
        }
    }
}
