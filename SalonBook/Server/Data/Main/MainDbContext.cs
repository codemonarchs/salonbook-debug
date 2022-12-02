using SalonBook.Server.Data.Main.Entities;
using Microsoft.EntityFrameworkCore;

namespace SalonBook.Server.Data.Main
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}