using System.Linq.Expressions;

namespace aspireWorkshop.API.Domain;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetQueryable();
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Remove(T entity);
    void Update(T entity);
}
