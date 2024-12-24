using aspireWorkshop.API.Data;
using aspireWorkshop.API.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace aspireWorkshop.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task SetupDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PostContext>();

        await EnsureDatabaseAsync(dbContext);
        await RunMigrationsAsync(dbContext);
        await SeedDatabaseAsync(dbContext);
    }

    private static async Task EnsureDatabaseAsync(PostContext dbContext)
    {
        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync())
                await dbCreator.CreateAsync();
        });
    }

    private static async Task RunMigrationsAsync(PostContext dbContext)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await dbContext.Database.MigrateAsync();
        });
    }

    private static async Task SeedDatabaseAsync(PostContext dbContext)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Avoid duplicating seed data
            if (dbContext.Posts is not null && await dbContext.Posts.AnyAsync() is false)
            {
                dbContext.Posts.AddRange(new List<Post>
                {
                    new Post {Content = "Hello World!" },
                    new Post {Content = "This is a seeded post." }
                });

                await dbContext.SaveChangesAsync();
            }
        });
    }
}
