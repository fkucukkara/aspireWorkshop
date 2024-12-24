using aspireWorkshop.Domain.Models;

namespace aspireWorkshop.Domain.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : Entity;
    Task<int> SaveChangesAsync();
}