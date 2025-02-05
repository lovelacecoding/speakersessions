using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Database;

public class FikaDbContext(DbContextOptions<FikaDbContext> options) : DbContext(options)
{
    public DbSet<FikaPastry> FikaPastries { get; set; }
}