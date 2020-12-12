using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.Entities.Concrete
{
    public class AppUser :IdentityUser<int>,ITable
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Notification> Notifications { get; set; }
        public List<Job> Jobs { get; set; }
    }   
}
