using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.Entities.Concrete
{
    public class Aciliyet:ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
