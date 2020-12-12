﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Interfaces;

namespace ToDoJob.Entities.Concrete
{
    public class Rapor:ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }


        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
