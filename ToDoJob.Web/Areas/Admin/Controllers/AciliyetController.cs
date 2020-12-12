using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoJob.Business.Interfaces;
using ToDoJob.DTO.DTOs.AciliyetDtos;
using ToDoJob.Entities.Concrete;
using ToDoJob.Web.StringInfo;

namespace ToDoJob.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class AciliyetController : Controller
    {
        private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;
        public AciliyetController(IAciliyetService aciliyetService, IMapper mapper)
        {
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            return View(_mapper.Map<List<AciliyetListDto>>(_aciliyetService.GetAll()));
        }

        public IActionResult AddAciliyet()
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            return View(new AddAciliyetDto());
        }

        [HttpPost]
        public IActionResult AddAciliyet(AddAciliyetDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Add(new Aciliyet()
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UpdateAciliyet(int id)
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            return View(_mapper.Map<UpdateAciliyetDto>(_aciliyetService.GetById(id)));
        }

        [HttpPost]
        public IActionResult UpdateAciliyet(UpdateAciliyetDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Update(new Aciliyet()
                {
                    Id = model.Id,
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
