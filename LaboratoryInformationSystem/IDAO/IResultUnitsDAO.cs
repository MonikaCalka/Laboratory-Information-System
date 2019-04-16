using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IResultUnitsDAO
    {
        List<ResultUnitModel> ReadResultUnitsList();
        ResultUnitModel ReadResultUnitModelById(long id);
        List<ResultUnitModel> ReadResultUnitModelByResultId(long id);
    }
}
