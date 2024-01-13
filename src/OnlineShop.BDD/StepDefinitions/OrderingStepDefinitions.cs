using OnlineShop.Domain.Aggregates.OrderAggregate;
using TechTalk.SpecFlow.Assist;

namespace OnlineShop.BDD.StepDefinitions
{
    [Binding]
    public class OrderingStepDefinitions
    {
        Order? order = null;

        [Given(@"I entered the following data into the new order form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewOrderForm(Table table)
        {
            order = table.CreateInstance<Order>();
        }

        [Given(@"I entered the following order items into the order form:")]
        public void GivenIEnteredTheFollowingOrderItemsIntoTheOrderForm(Table table)
        {
            var orderItems = table.CreateSet<OrderItem>();
            foreach (var item in orderItems)
            {
                order.AddOrderItem(item.ProductId, item.UnitPrice, item.Units);
            }
        }

        [When(@"the order price is calculated and the result should be (.*)")]
        public void WhenTheOrderPriceIsCalculatedAndTheResultShouldBe(Decimal result)
        {
            Assert.Equal(result, order.PayableAmount);
        }
    }
}
