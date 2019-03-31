﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.Models
{
    public class SampleModel
    {
        public long IdSample { get; set; }

        public EmployeeModel Employee { get; set; }

        public StudyModel Study { get; set; }

        public DateTime DateOfCollecion { get; set; }

        public string Code { get; set; }
    }
}