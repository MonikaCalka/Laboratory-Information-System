using LaboratoryInformationSystem.Enums;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IDictionaryDAO
    {
        List<DictionaryModel> ReadDictionaryListByType(DictionaryTypesEnum type, string lang);
        DictionaryModel ReadDictionaryById(DictionaryTypesEnum type, long? id, string lang);
    }
}
