using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoJob.Business.Interfaces;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.BaseController;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class JobController : BaseIdentityController
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
       public JobController(IJobService jobService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
       {
           _jobService = jobService;
            _mapper = mapper;
       }

        public async Task<IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = TempdataInfo.Job;

            var user = await GetSignInUser();
            var jobs = _mapper.Map<List<JobAllListDto>>(_jobService.GetAllTablesComplete(out int totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(jobs);
        }
    }
}
