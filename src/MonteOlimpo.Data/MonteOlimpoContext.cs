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

        public MonteOlimpoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<God>().HasKey(c => c.Id);
        }
    }
}