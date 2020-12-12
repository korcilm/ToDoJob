using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Business.Interfaces;
using ToDoJob.DataAccess.Concrete.EntityFramework.Repositories;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Concrete
{
    public class AciliyetManager:IAciliyetService
    {
        private readonly IAciliyetDal _aciliyetDal;

        public AciliyetManager(IAciliyetDal aciliyetDal)
        {
            _aciliyetDal = aciliyetDal;
        }
        public void Add(Aciliyet table)
        {
            _aciliyetDal.Add(table);
        }

        public void Delete(Aciliyet table)
        {
            _aciliyetDal.Delete(table);
        }

        public void Update(Aciliyet table)
        {
            _aciliyetDal.Update(table);
        }

        public Aciliyet GetById(int id)
        {
            return _aciliyetDal.GetById(id);
        }

        public List<Aciliyet> GetAll()
        {
            return _aciliyetDal.GetAll();
        }
    }
}
