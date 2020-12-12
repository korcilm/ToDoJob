using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Business.Interfaces;
using ToDoJob.DataAccess.Concrete.EntityFramework.Repositories;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Concrete
{
    public class RaporManager : IRaporService
    {
        private readonly IRaporDal _raporDal;

        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }

        public void Add(Rapor table)
        {
            _raporDal.Add(table);
        }

        public void Delete(Rapor table)
        {
            _raporDal.Delete(table);
        }

        public void Update(Rapor table)
        {
            _raporDal.Update(table);
        }

        public Rapor GetById(int id)
        {
            return _raporDal.GetById(id);
        }

        public List<Rapor> GetAll()
        {
            return _raporDal.GetAll();
        }

        public Rapor GetJobWithId(int id)
        {
            return _raporDal.GetJobWithId(id);
        }

        public int GetRaporNumberWithAppUserId(int id)
        {
            return _raporDal.GetRaporNumberWithAppUserId(id);
        }

        public int GetRaporCount()
        {
            return _raporDal.GetRaporCount();
        }
    }
}
