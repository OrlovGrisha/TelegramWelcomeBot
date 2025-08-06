using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class BotContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public BotContext(DbContextOptions<BotContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}