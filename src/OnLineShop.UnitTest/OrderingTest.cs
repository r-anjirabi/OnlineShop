using OnlineShop.Domain;
using OnlineShop.Domain.Aggregates.OrderAggregate;

namespace OnlineShop.UnitTest
{
    public class OrderingTest
    {
        [Fact]
        public void Create_order_ok()
        {
            var customerId = 1;
            var address = "tehran";
            var discount = 10;
            var profit = 1000;

            var order = new Order(customerId, address, discount, profit);

            Assert.NotNull(order);
        }

        [Fact]
        public void Create_order_with_orderItems_ok()
        {
            var customerId = 1;
            var address = "tehran";
            var discount = 10;
            decimal profit = 1000;

            var order = new Order(customerId, address, discount, profit);

            var firstProductId = 1;
            decimal firstUnitPrice = 10;
            var firstUnits = 2;
            order.AddOrderItem(firstProductId, firstUnitPrice, firstUnits);

            var secondProductId = 2;
            decimal secondUnitPrice = 100;
            var secondUnits = 3;
            order.AddOrderItem(secondProductId, secondUnitPrice, secondUnits);

            Assert.True(order.OrderStatus == OrderStatus.Submitted);
            Assert.True(order.OrderItems.Count == 2);

            var total = (firstUnits * firstUnitPrice) + (secondUnits * secondUnitPrice);
            Assert.Equal(total, order.Total);

            var payableAmount = total - (total / 100.0m * discount) + profit;
            Assert.Equal(payableAmount, order.PayableAmount);
        }

        [Fact]
        public void Invalid_set_shipment()
        {
            var order = new Order(1, "address");

            Assert.Throws<DomainException>(() => order.SetShipped("shipcode"));
        }

        [Fact]
        public void Invalid_add_order_item()
        {
            var order = new Order(1, "address");

            order.SetPaidStatus("paycode");

            Assert.Throws<DomainException>(() => order.AddOrderItem(1, 10));
        }
    }
}