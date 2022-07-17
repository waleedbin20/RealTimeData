using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealTimeMVCapp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            /*if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
            }
            else
            {
                host.Run();

            }*/

        }

        /*public static void RunSeeding(IWebHost host)
        {
            // this will create a scope - for every request there will be a lifetime scope for that request

            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                // it creates an instance of DutchSeeder and fills all it dependecies
                var seeder = scope.ServiceProvider.GetService<RealTimeSeeder>();
                seeder.seedMaterials();
            }
        }*/


        public static IWebHost BuildWebHost(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration(SetupConfiguration)

               .UseStartup<Startup>()
               .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            // addjosn is the development file and the enviroment is the override to that -- ORDER MATTERS
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json", false, true).AddEnvironmentVariables();
        }
    }
}
