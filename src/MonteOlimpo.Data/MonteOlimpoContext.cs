using Microsoft.EntityFrameworkCore;
using MonteOlimpo.Domain.Models;

namespace MonteOlimpo.Data
{
   public class MonteOlimpoContext : DbContext
    {
        public DbSet<Good> Good { get; set; }

        public MonteOlimpoContext(DbContextOptions<MonteOlimpoContext> options) :
           base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>().HasKey(c => c.Id);
        }
    }
}