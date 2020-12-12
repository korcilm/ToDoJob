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

namespace ToDoJob.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IJobService _jobService;
        private readonly INotificationService _notificationService;
        private readonly IRaporService _raporService;
        public HomeController(IJobService jobService, INotificationService notificationService, UserManager<AppUser> userManager, IRaporService raporService):base(userManager)
        {
            _jobService = jobService;
            _notificationService = notificationService;
            _raporService = raporService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";

            var user = await GetSignInUser();

            ViewBag.AtanmayanJob = _jobService.GetAtanmayanJob();
            ViewBag.CompletedJob = _jobService.GetCompletedJob();
            ViewBag.UnreadNotification = _notificationService.GetUnreadCountWithAppUserId(user.Id);
            ViewBag.TotalRaporCount = _raporService.GetRaporCount();


            return View();
        }
    }
}
