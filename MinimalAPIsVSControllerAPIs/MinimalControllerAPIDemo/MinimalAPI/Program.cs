using Microsoft.EntityFrameworkCore;
using MinimalAPI.Database;
using MinimalAPI.EndpointGroups;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FikaDbContext>(options => options.UseSqlite("Data Source=Database/fika.db"));

var app = builder.Build();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/helloworld", () => "hello world");

FikaEndpoints.MapFikaPastryEndpoints(app);

// app.MapGet("/api/fikapastries", async (FikaDbContext db) => await db.FikaPastries.ToListAsync());
//
// app.MapGet("/api/fikapastries/{id}", async (int id, FikaDbContext db) =>
// {
//     var pastry = await db.FikaPastries.FindAsync(id);
//     return pastry is not null ? Results.Ok(pastry) : Results.NotFound();
// });
//
// app.MapPost("/api/fikapastries", async (FikaPastry pastry, FikaDbContext db) =>
// {
//     db.FikaPastries.Add(pastry);
//     await db.SaveChangesAsync();
//     return Results.Created($"/api/fikapastries/{pastry.Id}", pastry);
// });
//
app.MapPut("/api/fikapastries/{id}", async (int id, FikaPastry updatedPastry, FikaDbContext db) =>
{
    if (id != updatedPastry.Id) return Results.BadRequest();
    db.Entry(updatedPastry).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
//
// app.MapDelete("/api/fikapastries/{id}", async (int id, FikaDbContext db) =>
// {
//     var pastry = await db.FikaPastries.FindAsync(id);
//     if (pastry is null) return Results.NotFound();
//     db.FikaPastries.Remove(pastry);
//     await db.SaveChangesAsync();
//     return Results.NoContent();
// });

app.Run();
