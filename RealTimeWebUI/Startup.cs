using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;


namespace RealTimeWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app)
        {
    
            app.UseRouting();

            // this will use the index file
            app.UseStaticFiles();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "/{Controller}/{action}/{id?}",
                    new
                    {
                        Controller = "Home",
                        action = "Index"
                    });


                
            });
        }
    }
}

