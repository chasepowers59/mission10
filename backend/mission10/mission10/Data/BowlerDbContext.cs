using Microsoft.EntityFrameworkCore;

namespace mission10.Data
{
    public class BowlerDbContext : DbContext
    {
        public BowlerDbContext(DbContextOptions<BowlerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Bowlers)
                .WithOne(b => b.Team)
                .HasForeignKey(b => b.TeamID);
        }
    }
}