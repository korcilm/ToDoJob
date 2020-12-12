using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAciliyetRepository:EfGenericRepository<Aciliyet>,IAciliyetDal
    {
    }
}
