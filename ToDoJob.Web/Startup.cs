using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoJob.Business.Concrete;
using ToDoJob.Business.DIContainer;
using ToDoJob.Business.Interfaces;
using ToDoJob.Business.ValidationRules.FluentValidation;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Concrete.EntityFramework.Repositories;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.DTO.DTOs.AciliyetDtos;
using ToDoJob.DTO.DTOs.AppUserDtos;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.DTO.DTOs.RaporDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.CustomCollectionExtensions;

namespace ToDoJob.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();
            services.AddDbContext<ToDoJobContext>();
            services.AddCustomIdentity();
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomValidator(); 
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{action=Index}/{Id?}");
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{Id?}");
                });
        }
    }
}
