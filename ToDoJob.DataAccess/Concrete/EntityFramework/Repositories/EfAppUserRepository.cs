using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNotBeAdmin()
        {
            using var context = new ToDoJobContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                }).ToList();
        }
        public List<AppUser> GetNotBeAdmin(out int totalPage,string keyword, int activePage = 1)
        {
            using var context = new ToDoJobContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                });

            totalPage = (int)Math.Ceiling((double)result.Count()/3);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(I =>
                    I.Name.ToLower().Contains(keyword.ToLower()) || I.SurName.ToLower().Contains(keyword.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }

        //En çok iş tamamlayan
        public List<DualHelper> GetMostCompletedJob()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.AppUser).Where(I => I.State).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                JobCount = I.Count()
            }).ToList();
        }

        //En çok işte çalışan
        public List<DualHelper> GetMostAtananJob()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.AppUser).Where(I => !I.State && I.AppUserId != null).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                JobCount = I.Count()
            }).ToList();
        }
    }
}
