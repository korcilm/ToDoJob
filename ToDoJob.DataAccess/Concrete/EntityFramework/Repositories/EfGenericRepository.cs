using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table> where Table : class, ITable, new()
    {
        public void Add(Table table)
        {
            using var context = new ToDoJobContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Delete(Table table)
        {
            using var context = new ToDoJobContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            using var context = new ToDoJobContext();
            return context.Set<Table>().ToList();
        }

        public Table GetById(int id)
        {
            using var context = new ToDoJobContext();
            return context.Set<Table>().Find(id);
        }

        public void Update(Table table)
        {
            using var context = new ToDoJobContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
    }
}
