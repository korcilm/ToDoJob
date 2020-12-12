using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Interfaces
{
    public interface IRaporService:IGenericService<Rapor>
    {
        Rapor GetJobWithId(int id);
        int GetRaporNumberWithAppUserId(int id);
        int GetRaporCount();
    }
}
