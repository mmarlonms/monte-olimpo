using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.ApiBoot;
using MonteOlimpo.Base.Core.Data.UnitOfWork;
using MonteOlimpo.Base.Core.Domain.UnitOfWork;
using MonteOlimpo.Data;
using MonteOlimpo.Repository;
using System.Collections.Generic;
using System.Reflection;

namespace MonteOlimpo.WebApi
{
    public class Startup : MonteOlimpoBootStrap
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<MonteOlimpoContext>(
                   options => options.UseNpgsql(
                       Configuration.GetConnectionString(nameof(MonteOlimpoContext))));

            services.AddScoped<IUnitOfWork, UnitOfWork<MonteOlimpoContext>>();
        }

        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(GoodRepository).Assembly;
        }
    }
}