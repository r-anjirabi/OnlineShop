namespace OnlineShop.Domain.Base
{
    internal interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
