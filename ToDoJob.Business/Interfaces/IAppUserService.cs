using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNotBeAdmin();
        List<AppUser> GetNotBeAdmin(out int totalPage, string keyword, int activePage = 1);
        List<DualHelper> GetMostCompletedJob();
        List<DualHelper> GetMostAtananJob();
    }
}
