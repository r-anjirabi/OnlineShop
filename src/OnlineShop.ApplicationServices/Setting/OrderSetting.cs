using OnlineShop.ApplicationServices.Setting;

namespace OnlineShop.ApplicationServices
{
    internal class OrderSetting : IOrderSetting
    {
        public int OrderingStartHour { get; set; }
        public int OrderingEndHour { get; set; }
        public decimal MinimumOrderPrice { get; set; }

    }
}
