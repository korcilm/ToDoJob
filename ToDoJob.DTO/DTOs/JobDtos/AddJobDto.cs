using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoJob.DTO.DTOs.JobDtos
{
    public class AddJobDto
    {
       // [Required(ErrorMessage = "Ad alanı gerekli")]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Range(0, Int32.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz")]
        public int AciliyetId { get; set; }
    }
}
