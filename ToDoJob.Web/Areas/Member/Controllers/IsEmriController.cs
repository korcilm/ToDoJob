using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoJob.Business.Interfaces;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.DTO.DTOs.RaporDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.BaseController;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class IsEmriController : BaseIdentityController
    {
        private readonly IJobService _jobService;
        private readonly IRaporService _raporService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public IsEmriController(IJobService jobService, UserManager<AppUser> userManager, IRaporService raporService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            _jobService = jobService;
            _raporService = raporService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.IsEmri;

            var user = await GetSignInUser();            
            return View(_mapper.Map<List<JobAllListDto>>(_jobService.GetAllTables(I => I.AppUserId == user.Id && !I.State)));
        }

        public IActionResult AddRapor(int id)
        {
            var job = _jobService.GetByAciliyetId(id);

            AddRaporDto model = new AddRaporDto
            {
                JobId = id,
                Job = job
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRapor(AddRaporDto model)
        {
            if (ModelState.IsValid)
            {
                _raporService.Add(new Rapor()
                {
                    Description = model.Description,
                    Detail = model.Detail,
                    JobId = model.JobId
                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await GetSignInUser();

                foreach (var admin in adminUserList)
                {
                    _notificationService.Add(new Notification
                    {
                        Description = $"{activeUser.Name} {activeUser.SurName} yeni bir rapor yazdı",
                        AppUserId=admin.Id
                    });
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UpdateRapor(int id)
        {
            TempData["Active"] = TempdataInfo.IsEmri;

            var rapor = _raporService.GetJobWithId(id);
            UpdateRaporDto model = new UpdateRaporDto
            {
                Id = rapor.Id,
                Description = rapor.Description,
                Detail = rapor.Detail,
                Job = rapor.Job,
                JobId = rapor.JobId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateRapor(UpdateRaporDto model)
        {
            if (ModelState.IsValid)
            {
                var rapor = _raporService.GetJobWithId(model.Id);
                rapor.Description = model.Description;
                rapor.Detail = model.Detail;
                _raporService.Update(rapor);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> CompleteJob(int jobId)
        {
            var updatingJob= _jobService.GetById(jobId);
            updatingJob.State = true;
            _jobService.Update(updatingJob);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await GetSignInUser();

            foreach (var admin in adminUserList)
            {
                _notificationService.Add(new Notification
                {
                    Description = $"{activeUser.Name} {activeUser.SurName} vermiş olduğunuz bir görevi tamamladı",
                    AppUserId = admin.Id
                });
            }
            return Json(null);
        }
    }
}
