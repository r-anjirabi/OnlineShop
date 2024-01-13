using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Entities.Customer
{
    internal class Customer : Entity
    {
        public string Name { get; private set; }
        public Customer(string name)
        {
            Name = name;
        }
    }
}
