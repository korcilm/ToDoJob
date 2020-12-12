using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Interfaces
{
    public interface IJobService: IGenericService<Job>
    {
        List<Job> GetByIdWithAciliyet();
        List<Job> GetAllTables();
        List<Job> GetAllTables(Expression<Func<Job, bool>> filter);
        List<Job> GetAllTablesComplete(out int totalPage, int userId, int activePage=1);
        Job GetByAciliyetId(int id);
        List<Job> GetByAppUserId(int userId);
        Job GetByIdwithRaporlar(int id);
        int GetJobCountComletedWithAppUserId(int id);
        int GetJobCountWaitingWithAppUserId(int id);
        int GetAtanmayanJob();
        int GetCompletedJob();
    }
}
