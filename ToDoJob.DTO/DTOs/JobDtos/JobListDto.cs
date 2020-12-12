using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DTO.DTOs.JobDtos
{
    public class JobListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool State { get; set; }

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }
    }
}
