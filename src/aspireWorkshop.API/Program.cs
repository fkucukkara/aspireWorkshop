using aspireWorkshop.API.Data;
using aspireWorkshop.API.Domain;
using aspireWorkshop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.AddSqlServerDbContext<PostContext>("sqlDb");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.AddServiceDefaults();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();
app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    await app.SetupDatabaseAsync();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var v1 = app.MapGroup("/aspireWorkshop/v1/posts");

v1.MapGet("/", async Task<IResult> (IUnitOfWork unitOfWork) =>
{
    return TypedResults.Ok(await unitOfWork.Repository<Post>().GetAllAsync());
});

v1.MapGet("/{id}", async Task<IResult> (IUnitOfWork unitOfWork, int id) =>
{
    return await unitOfWork.Repository<Post>().GetByIdAsync(id)
        is Post post
            ? TypedResults.Ok(post)
            : TypedResults.NotFound();
});

v1.MapPost("/", async Task<IResult> (IUnitOfWork unitOfWork, Post post) =>
{
    await unitOfWork.Repository<Post>().AddAsync(post);
    await unitOfWork.SaveChangesAsync();

    return TypedResults.Created($"/aspireWorkshop/v1/posts/{post.Id}", post);
});

v1.MapPut("/{id}", async Task<IResult> (IUnitOfWork unitOfWork, int id, Post post) =>
{
    var existingPost = await unitOfWork.Repository<Post>().GetByIdAsync(id);
    if (existingPost is null) return TypedResults.NotFound();

    existingPost.Content = post.Content;
    await unitOfWork.SaveChangesAsync();

    return TypedResults.NoContent();
});

v1.MapDelete("/{id}", async Task<IResult> (IUnitOfWork unitOfWork, int id) =>
{
    if (await unitOfWork.Repository<Post>().GetByIdAsync(id) is Post post)
    {
        unitOfWork.Repository<Post>().Remove(post);
        await unitOfWork.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
});

app.Run();