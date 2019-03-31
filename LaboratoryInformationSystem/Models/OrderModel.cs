using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.Models
{
    public class OrderModel
    {
        public long IdOrder { get; set; }

        public PatientModel Patient { get; set; }

        public EmployeeModel Employee { get; set; }

        public DictionaryModel Ward { get; set; }

        public string Institution { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfOrder { get; set; }

        public DateTime? DateOfReceived { get; set; }

        public DictionaryModel Status { get; set; }

        public DictionaryModel Priority { get; set; }

        public List<EmployeeModel> Consultants { get; set; }
    }
}