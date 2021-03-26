namespace User.Domain.UnitOfWork
{
    using User.Domain.Repositories;
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        void StartTransaction();
        void Commit();
    }
}
