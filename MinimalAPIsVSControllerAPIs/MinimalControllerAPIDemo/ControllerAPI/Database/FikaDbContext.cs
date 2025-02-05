using ControllerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerAPI.Database;

public class FikaDbContext(DbContextOptions<FikaDbContext> options) : DbContext(options)
{
    public DbSet<FikaPastry> FikaPastries { get; set; }
}