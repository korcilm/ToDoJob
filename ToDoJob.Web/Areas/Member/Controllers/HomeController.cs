using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoJob.Business.Interfaces;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.BaseController;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IRaporService _raporService;
        private readonly IJobService _jobService;
        private readonly INotificationService _notificationService;
        public HomeController(IRaporService raporService, UserManager<AppUser> userManager, IJobService jobService, INotificationService notificationService):base(userManager)
        {
            _raporService = raporService;
            _jobService = jobService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Home;
            var user = await GetSignInUser();
            ViewBag.RaporSayisi = _raporService.GetRaporNumberWithAppUserId(user.Id);
            ViewBag.CompletedJob = _jobService.GetJobCountComletedWithAppUserId(user.Id);
            ViewBag.WaitingJob = _jobService.GetJobCountWaitingWithAppUserId(user.Id);
            ViewBag.UnreadNotification = _notificationService.GetUnreadCountWithAppUserId(user.Id);

            return View();
        }
    }
}
