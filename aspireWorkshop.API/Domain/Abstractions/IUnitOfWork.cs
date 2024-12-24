namespace aspireWorkshop.API.Domain;
public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : Entity;
    Task<int> SaveChangesAsync();
}