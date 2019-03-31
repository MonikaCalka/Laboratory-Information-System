using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.Models
{
    public class StudyModel
    {
        public long IdStudy { get; set; }

        public ProfileModel Profile { get; set; }

        public EmployeeModel Employee { get; set; }

        public OrderModel Order { get; set; }

        public DictionaryModel Status { get; set; }

        public DateTime DateOfStudy { get; set; }
    }
}