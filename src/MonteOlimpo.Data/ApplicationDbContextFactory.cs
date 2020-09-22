using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MonteOlimpo.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MonteOlimpoContext>
    {
        public MonteOlimpoContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MonteOlimpoContext>();
            builder.UseSqlServer("Server=localhost;Database=cnet_auth;User ID=sa;Password=Contr@tanet",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MonteOlimpoContext).GetTypeInfo().Assembly.GetName().Name))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new MonteOlimpoContext(builder.Options);
        }
    }
}