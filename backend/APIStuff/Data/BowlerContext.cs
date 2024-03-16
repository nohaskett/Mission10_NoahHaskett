using Microsoft.EntityFrameworkCore;

namespace APIStuff.Data
{
    public class BowlerContext : DbContext
    {
        public BowlerContext(DbContextOptions<BowlerContext> options) : base(options) { }

        public DbSet<Bowlers> Bowlers { get; set; }
        public DbSet<Teams> Teams { get; set; }

    }
}
