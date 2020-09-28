using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Base.Core.CrossCutting;
using MonteOlimpo.Data;
using MonteOlimpo.Domain.Validator;
using System;
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
           
            //Registra data base
            services.RegisterMonteOlimpoDataBase<MonteOlimpoContext>(Configuration);
            //ADD autenticação via JWT
            services.AddJwtAuthentication(Configuration);
            
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication(); 
            base.Configure(app, env);
        }

        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(Startup).Assembly;
            yield return AppDomain.CurrentDomain.Load("MonteOlimpo.Data");
            yield return AppDomain.CurrentDomain.Load("MonteOlimpo.Domain");
            yield return AppDomain.CurrentDomain.Load("MonteOlimpo.Repository");
            yield return AppDomain.CurrentDomain.Load("MonteOlimpo.Service");
        }

        protected override IEnumerable<Assembly> GetValidationAssemblies()
        {
            yield return typeof(GodValidator).Assembly;
        }
    }
}