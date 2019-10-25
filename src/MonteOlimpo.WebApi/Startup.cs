﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Base.Authentication;
using MonteOlimpo.Base.Core.CrossCutting;
using MonteOlimpo.Base.Filters.Exceptions;
using MonteOlimpo.Base.Filters.Validation;
using MonteOlimpo.Data;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Validator;
using MonteOlimpo.Repository;
using MonteOlimpo.Service;
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

            //ADD autenticação via JWT
            services.AddJWTAuthenticationClient(Configuration.GetSection("TokenConfigurations").Get<TokenConfigurations>());
            //Registra data base
            services.RegisterMonteOlimpoDataBase<MonteOlimpoContext>(Configuration);
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            base.Configure(app, env);
        }

        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(GodRepository).Assembly;
            yield return typeof(GodService).Assembly;
        }

        protected override IEnumerable<Assembly> GetValidationAssemblies()
        {
            yield return typeof(GodValidator).Assembly;
        }
    }
}