using CourseBasket.Domain.Repositories;

namespace CourseBasket.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBasketRepository Basket { get; }
    }
}
