using aspireWorkshop.API.Domain;

namespace aspireWorkshop.API.Data;
public class PostContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post>? Posts { get; set; }
}
