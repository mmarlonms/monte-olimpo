
using Microsoft.EntityFrameworkCore;
using MonteOlimpo.Domain.Models;


namespace MonteOlimpo.Data
{
    public class MonteOlimpoContext : DbContext
    {
        public DbSet<God> God { get; set; }

        public MonteOlimpoContext(DbContextOptions<MonteOlimpoContext> options) :
          base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<God>().HasKey(c => c.Id);

            modelBuilder.Entity<God>(god =>
            {
                god.HasKey(c => c.Id);
                god.Property(e => e.Id).ValueGeneratedOnAdd();
            });


        }
    }
}
