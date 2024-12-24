using aspireWorkshop.API.Data;
using aspireWorkshop.API.Domain;
using aspireWorkshop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<PostContext>("sqlDb");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    await app.SetupDatabaseAsync();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var v1 = app.MapGroup("/aspireWorkshop/v1/posts");

v1.MapGet("/", async (IUnitOfWork unitOfWork) =>
{
    var products = await unitOfWork.Repository<Post>().GetAllAsync();
    return TypedResults.Ok(products);
});

app.Run();