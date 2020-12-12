using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.DataAccess.Interfaces
{
    public interface IGenericDal<Table> where Table : class, ITable, new()
    {
        void Add(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
