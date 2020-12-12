using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.DTO.DTOs.JobDtos;

namespace ToDoJob.DTO.DTOs.AppUserDtos
{
    public class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public JobListDto Job { get; set; }
    }
}
