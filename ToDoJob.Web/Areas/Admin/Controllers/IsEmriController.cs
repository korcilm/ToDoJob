using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoJob.Business.Interfaces;
using ToDoJob.DTO.DTOs.AppUserDtos;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJobService _jobService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public IsEmriController(IAppUserService appUserService, IJobService jobService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _appUserService = appUserService;
            _jobService = jobService;
            _userManager = userManager;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.IsEmri;
            return View(_mapper.Map<List<JobAllListDto>>(_jobService.GetAllTables()));
        }

        public IActionResult Detail(int id)
        {
            TempData["Active"] = TempdataInfo.IsEmri;
            return View(_mapper.Map<JobAllListDto>(_jobService.GetByIdwithRaporlar(id)));
        }

        public IActionResult GetExcel(int id)
        {
            return File(_fileService.AktarExcel(_jobService.GetByIdwithRaporlar(id).Raporlar), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.AktarPdf(_jobService.GetByIdwithRaporlar(id).Raporlar);
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
        public IActionResult AtaPersonel(int id, string s, int page = 1)
        {
            TempData["Active"] = TempdataInfo.IsEmri;

            ViewBag.ActivePage = page;
            //ViewBag.TotalPage =(int)Math.Ceiling((double) _appUserService.GetNotBeAdmin().Count/3);

            var personeller = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNotBeAdmin(out int totalPage, s, page));

            ViewBag.TotalPage = totalPage;
            ViewBag.Searching = s;
            ViewBag.Personeller = personeller;

            return View(_mapper.Map<JobListDto>(_jobService.GetByAciliyetId(id)));
        }

        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirDto model)
        {
            var guncellenecekGorev = _jobService.GetById(model.JobId);
            guncellenecekGorev.AppUserId = model.PersonelId;

            _jobService.Update(guncellenecekGorev);
            _jobService.Update(guncellenecekGorev);

            _notificationService.Add(new Notification
            {
                AppUserId = model.PersonelId,
                Description = $"{guncellenecekGorev.Name} adlı iş için görevlendirildiniz."
            });

            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirDto model)
        {
            TempData["Active"] = TempdataInfo.IsEmri;

            PersonelGorevlendirListDto personelGorevlendir = new PersonelGorevlendirListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId)),
                Job = _mapper.Map<JobListDto>(_jobService.GetByAciliyetId(model.JobId))
            };

            return View(personelGorevlendir);
        }
    }
}
