using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MonteOlimpo.Base.Extensions.Configuration;

namespace MonteOlimpo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(ConfigurationExtensions.AddMonteOlimpoConfiguration)
                .UseStartup<Startup>();
    }
}