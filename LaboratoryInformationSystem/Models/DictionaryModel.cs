using LaboratoryInformationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.Models
{
    public class DictionaryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DictionaryTypesEnum Type { get; set; }
    }
}