using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoJob.Business.Interfaces;
using ToDoJob.DataAccess.Concrete.EntityFramework.Repositories;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public void Add(Job table)
        {
            _jobDal.Add(table);
        }

        public void Delete(Job table)
        {
            _jobDal.Delete(table);
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public Job GetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> GetByIdWithAciliyet()
        {
            return _jobDal.GetByIdWithAciliyet();
        }

        public List<Job> GetAllTables()
        {
            return _jobDal.GetAllTables();
        }

        public List<Job> GetAllTables(Expression<Func<Job, bool>> filter)
        {
            return _jobDal.GetAllTables(filter);
        }

        public List<Job> GetAllTablesComplete(out int totalPage, int userId, int activePage)
        {
            return _jobDal.GetAllTablesComplete(out totalPage, userId, activePage);
        }

        public List<Job> GetByAppUserId(int userId)
        {
            return _jobDal.GetByAppUserId(userId);
        }

        public Job GetByIdwithRaporlar(int id)
        {
            return _jobDal.GetByIdwithRaporlar(id);
        }

        public void Update(Job table)
        {
            _jobDal.Update(table);
        }

        public Job GetByAciliyetId(int id)
        {
            return _jobDal.GetByAciliyetId(id);
        }

        public int GetJobCountComletedWithAppUserId(int id)
        {
            return _jobDal.GetJobCountComletedWithAppUserId(id);
        }

        public int GetJobCountWaitingWithAppUserId(int id)
        {
            return _jobDal.GetJobCountWaitingWithAppUserId(id);
        }

        public int GetAtanmayanJob()
        {
            return _jobDal.GetAtanmayanJob();
        }

        public int GetCompletedJob()
        {
            return _jobDal.GetCompletedJob();
        }
    }
}
