namespace Course.Domain.UnitOfWork
{
    using Course.Domain.Repositories;
    public interface IUnitOfWork
    {
        ICourseRepository Users { get; }
        void StartTransaction();
        void Commit();
    }
}
