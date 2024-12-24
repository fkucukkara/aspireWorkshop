using aspireWorkshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace aspireWorkshop.Data;
public class PostContext : DbContext
{
    public PostContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post>? Posts { get; set; }
}
