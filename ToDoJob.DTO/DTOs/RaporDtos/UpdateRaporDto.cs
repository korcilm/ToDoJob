using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DTO.DTOs.RaporDtos
{
    public class UpdateRaporDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım :")]
        //[Required(ErrorMessage = "Tanım alanı boş geçilemez.")]
        public string Description { get; set; }

        //[Display(Name = "Detay :")]
        //[Required(ErrorMessage = "Detay alanı boş geçilemez.")]
        public string Detail { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
