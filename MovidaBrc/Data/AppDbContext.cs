using Microsoft.EntityFrameworkCore;
using MovidaBrcSharedLibrary.Models;

namespace MovidaBrc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Fiesta> Fiestas { get; set; } = default!;
    }
}
