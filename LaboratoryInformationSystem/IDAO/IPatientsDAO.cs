using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IPatientsDAO
    {
        List<PatientModel> ReadPatientsList();
        PatientModel ReadPatientById(int id);
    }
}
