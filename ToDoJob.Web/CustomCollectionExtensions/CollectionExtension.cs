using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoJob.Business.ValidationRules.FluentValidation;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DTO.DTOs.AciliyetDtos;
using ToDoJob.DTO.DTOs.AppUserDtos;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.DTO.DTOs.RaporDtos;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
            }).AddEntityFrameworkStores<ToDoJobContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddAciliyetDto>, AddAciliyetValidator>();
            services.AddTransient<IValidator<UpdateAciliyetDto>, UpdateAciliyetValidator>();
            services.AddTransient<IValidator<AddUserDto>, AddUserValidator>();
            services.AddTransient<IValidator<UserSignInDto>, UserSignInValidator>();
            services.AddTransient<IValidator<AddJobDto>, AddJobValidator>();
            services.AddTransient<IValidator<UpdateJobDto>, UpdateJobValidator>();
            services.AddTransient<IValidator<AddRaporDto>, AddRaporValidator>();
            services.AddTransient<IValidator<UpdateRaporDto>, UpdateRaporValidator>();
        }
    }
}
