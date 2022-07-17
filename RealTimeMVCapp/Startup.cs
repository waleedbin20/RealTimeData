
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RealTimeMVCapp.Context;
using RealTimeMVCapp.Repository;
using RealTimeMVCapp.SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RealTimeMVCapp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
  
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<RealTimeContext>();


            // CORS Middleware handles cross-origin requests from different domain
            services.AddCors(options =>
            {
                options.AddDefaultPolicy( builder =>
                {
                    builder.WithOrigins("https://waleedclient.azurewebsites.net")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                        .AllowCredentials();

                });
            });


            services.AddSignalR();
      
            // mapping for our controllers
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllersWithViews();

            services.AddTransient<IRealTimeRepository, RealTimeRepository>();

            // this is for handling loop referencing 
            /*services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);*/
            services.AddRazorPages();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // this will use the index file
            app.UseStaticFiles();

            //  adds the CORS middleware
            app.UseCors();


        app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute("Default", "/{Controller}/{action}/{id?}");
                endpoints.MapHub<BroadcastHub>("/notify");
            });
        }
    }
}
