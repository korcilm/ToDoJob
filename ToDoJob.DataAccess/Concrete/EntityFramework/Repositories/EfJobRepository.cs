using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfJobRepository : EfGenericRepository<Job>, IJobDal
    {
        public List<Job> GetByIdWithAciliyet()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.Aciliyet).Where(I => I.State == false)
                .OrderByDescending(I => I.CreateDate).ToList();
        }

        public Job GetByIdwithRaporlar(int id)
        {
            using var context=new ToDoJobContext();
            return context.Jobs.Include(I => I.Raporlar).Include(I => I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }
        public List<Job> GetAllTables()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser).Where(I => I.State == false)
                .OrderByDescending(I => I.CreateDate).ToList();
        }

        public List<Job> GetAllTables(Expression<Func<Job, bool>> filter)
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser).Where(filter)
                .OrderByDescending(I => I.CreateDate).ToList();
        }

        public List<Job> GetAllTablesComplete(out int totalPage, int userId, int activePage=1)
        {
            using var context = new ToDoJobContext();
            var returnValue= context.Jobs.Include(I => I.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser).Where(I=>I.AppUserId==userId && I.State)
                .OrderByDescending(I => I.CreateDate);

            totalPage = (int) Math.Ceiling((double) returnValue.Count() / 3);
            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public Job GetByAciliyetId(int id)
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Include(I => I.Aciliyet).FirstOrDefault(I => !I.State && I.Id == id);
        }

        public List<Job> GetByAppUserId(int userId)
        {
            using var context=new ToDoJobContext();
            return context.Jobs.Where(I => I.AppUserId == userId).ToList(); 
        }

        public int GetJobCountComletedWithAppUserId(int id)
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Count(I => I.AppUserId == id && I.State);
        }

        public int GetJobCountWaitingWithAppUserId(int id)
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Count(I => I.AppUserId == id && !I.State);
        }

        public int GetAtanmayanJob()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Count(I => I.AppUserId == null);
        }

        public int GetCompletedJob()
        {
            using var context = new ToDoJobContext();
            return context.Jobs.Count(I => I.State);
        }
    }
}
