using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRaporRepository : EfGenericRepository<Rapor>, IRaporDal
    {
        public Rapor GetJobWithId(int id)
        {
            using var context = new ToDoJobContext();
            return context.Raporlar.Include(I => I.Job).ThenInclude(I => I.Aciliyet).FirstOrDefault(I => I.Id == id);

        }

        public int GetRaporCount()
        {
            using var context = new ToDoJobContext();
            return context.Raporlar.Count();
        }

        public int GetRaporNumberWithAppUserId(int id)
        {
            using var context = new ToDoJobContext();
            var result = context.Jobs.Include(I => I.Raporlar).Where(I => I.AppUserId == id);

            return result.SelectMany(I => I.Raporlar).Count();
        }
    }
}
