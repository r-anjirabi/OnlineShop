namespace OnlineShop.ApplicationServices.Setting
{
    internal interface IOrderSetting
    {
        public int OrderingStartHour { get; set; }
        public int OrderingEndHour { get; set; }
        public decimal MinimumOrderPrice { get; set; }
    }
}
