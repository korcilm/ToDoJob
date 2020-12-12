 using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Interfaces
{
    public interface IRaporDal:IGenericDal<Rapor>
    {
        Rapor GetJobWithId(int id);
        int GetRaporNumberWithAppUserId(int id);
        int GetRaporCount();
    }
}
