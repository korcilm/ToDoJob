using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoJob.Business.Interfaces;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Graphic;
            return View();
        }
        public IActionResult MostCompletedJob()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostCompletedJob());
            return Json(jsonString);
        }
        public IActionResult MostAtananJob()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostAtananJob());
            return Json(jsonString);
        }
    }
}
