using BlogPAUPLatestYT.Data;
using BlogPAUPLatestYT.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using BlogPAUPLatestYT.Models;
using Microsoft.AspNetCore.SpaServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPAUPLatestYT.Data.FileManager;

namespace BlogPAUPLatestYT
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddIdentity<IdentityUser,IdentityRole>(options =>
             {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            
            })
                    //.AddRoles<IdentityRole>()
                    //.AddUserManager<IdentityUser>()
                    .AddEntityFrameworkStores<AppDBContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });

            services.AddMvc(options=>options.EnableEndpointRouting=false);

            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_config["DefaultConnection"]));

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IFileManager, FileManager>();
            

            //services.AddAuthentication();
            
            
            
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                  //  await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
