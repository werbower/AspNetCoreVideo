using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreVideo.Entities;
using Microsoft.AspNetCore.Identity;


namespace AspNetCoreVideo
{
    public class Startup    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env) {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",optional:true);
            //if (env.IsDevelopment()) {
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)        {
            //
            string conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options => {
                options.UseSqlServer(conn);
            });
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VideoDbContext>();

            services
                .AddScoped<IVideoData,SqlVideoData>()
                //.AddSingleton<IVideoData, MockVideoData>()
                .AddSingleton(provider=>Configuration)
                .AddSingleton<IMessageService, ConfigurationMessageService>()
                .AddMvc();
            
               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
            ,IMessageService msg)        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes=> {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>            {
                var message = Configuration["Message"];
                message = msg.GetMessage();
                //throw new Exception("Fake exception");
                await context.Response.WriteAsync(message);
            });
        }
    }
}
