using Microsoft.EntityFrameworkCore;

namespace aspireWorkshop.API;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ToDo> ToDos { get; set; }
}

public class ToDo
{
    public int Id { get; set; }
    public string Content { get; set; }
}