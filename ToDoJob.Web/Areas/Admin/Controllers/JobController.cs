using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoJob.Business.Interfaces;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class JobController : Controller
    {
        private readonly IAciliyetService _aciliyetService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, IAciliyetService aciliyetService, IMapper mapper)
        {
            _jobService = jobService;
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            TempData["Active"] = TempdataInfo.Job;
            return View(_mapper.Map<List<JobListDto>>(_jobService.GetByIdWithAciliyet()));
        }

        public IActionResult AddJob()
        {
            TempData["Active"] = TempdataInfo.Job;
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetAll(), "Id", "Description");
            return View(new AddJobDto());
        }
        [HttpPost]
        public IActionResult AddJob(AddJobDto model)
        {
            if (ModelState.IsValid)
            {
                _jobService.Add(new Job()
                {
                    Description = model.Description,
                    Name = model.Name,
                    AciliyetId = model.AciliyetId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetAll(), "Id", "Description");
            return View(model);
        }

        public IActionResult UpdateJob(int id)
        {
            TempData["Active"] = TempdataInfo.Job;
            var job = _jobService.GetById(id);
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetAll(), "Id", "Description", job.AciliyetId);
            return View(_mapper.Map<UpdateJobDto>(job));
        }
        [HttpPost]
        public IActionResult UpdateJob(UpdateJobDto model)
        {
            if (ModelState.IsValid)
            {
                _jobService.Update(new Job()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Name = model.Name,
                    AciliyetId = model.AciliyetId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetAll(), "Id", "Description", model.AciliyetId);
            return View(model);
        }

        public IActionResult DeleteJob(int id)
        {
            _jobService.Delete(new Job { Id = id });
            return Json(null);
        }
    }
}
