using aspireWorkshop.API.Domain;

namespace aspireWorkshop.API.Data;
public class PostContext : DbContext
{
    public PostContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post>? Posts { get; set; }
}
