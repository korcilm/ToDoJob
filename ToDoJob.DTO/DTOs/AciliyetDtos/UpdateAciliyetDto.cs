using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoJob.DTO.DTOs.AciliyetDtos
{
    public class UpdateAciliyetDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım : ")]
        //[Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Description { get; set; }
    }
}
