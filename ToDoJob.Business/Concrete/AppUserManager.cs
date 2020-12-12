using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Business.Interfaces;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Concrete
{
    public class AppUserManager:IAppUserService
    {
        private readonly IAppUserDal _userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<DualHelper> GetMostAtananJob()
        {
            return _userDal.GetMostAtananJob();
        }

        public List<DualHelper> GetMostCompletedJob()
        {
            return _userDal.GetMostCompletedJob();
        }

        public List<AppUser> GetNotBeAdmin()
        {
            return _userDal.GetNotBeAdmin();
        }

        public List<AppUser> GetNotBeAdmin(out int totalPage,string keyword, int activePage = 1)
        {
            return _userDal.GetNotBeAdmin(out totalPage, keyword, activePage);
        }
    }
}
