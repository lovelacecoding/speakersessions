using Microsoft.EntityFrameworkCore;
using SemanticKernelCopilotAPI.Models;

namespace SemanticKernelCopilotAPI.Data
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}