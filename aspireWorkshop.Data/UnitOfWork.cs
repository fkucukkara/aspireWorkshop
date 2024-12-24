using aspireWorkshop.Domain.Abstractions;
using aspireWorkshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace aspireWorkshop.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly PostContext _context;

    public UnitOfWork(PostContext context) => _context = context;

    public IRepository<T> Repository<T>() where T : Entity
    {
        return new GenericRepository<T>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose() => _context.Dispose();
}
