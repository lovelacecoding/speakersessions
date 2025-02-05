using Microsoft.EntityFrameworkCore;
using MinimalAPI.Database;
using MinimalAPI.Models;

namespace MinimalAPI.EndpointGroups;

public static class FikaEndpoints
{
    public static void MapFikaPastryEndpoints(WebApplication app)
    {
        var group = app.MapGroup("/api/fikapastries");

        group.MapGet("/", async (FikaDbContext db) => await db.FikaPastries.ToListAsync());

        group.MapGet("/{id:int}", async (int id, FikaDbContext db) =>
        {
            var pastry = await db.FikaPastries.FindAsync(id);
            return pastry is not null ? Results.Ok(pastry) : Results.NotFound();
        });

        group.MapPost("/", async (FikaPastry pastry, FikaDbContext db) =>
        {
            db.FikaPastries.Add(pastry);
            await db.SaveChangesAsync();
            return Results.Created($"/api/fikapastries/{pastry.Id}", pastry);
        });

        group.MapPut("/{id:int}", async (int id, FikaPastry updatedPastry, FikaDbContext db) =>
        {
            if (id != updatedPastry.Id) return Results.BadRequest();
            db.Entry(updatedPastry).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, FikaDbContext db) =>
        {
            var pastry = await db.FikaPastries.FindAsync(id);
            if (pastry is null) return Results.NotFound();
            db.FikaPastries.Remove(pastry);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}