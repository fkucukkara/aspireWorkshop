namespace aspireWorkshop.API.Data;
public class UnitOfWork(PostContext context) : IUnitOfWork
{
    public IRepository<T> Repository<T>() where T : Entity
    {
        return new GenericRepository<T>(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose() => context.Dispose();
}
