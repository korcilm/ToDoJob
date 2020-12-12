using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.Entities.Concrete
{
    public class Job:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now; 
        public bool State { get; set; }

        public int AciliyetId { get; set; }
        public Aciliyet Aciliyet { get; set; }  

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Rapor> Raporlar { get; set; }
    }
}
