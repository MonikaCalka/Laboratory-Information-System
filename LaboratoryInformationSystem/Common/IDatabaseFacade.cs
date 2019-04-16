using LaboratoryInformationSystem.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.Common
{
    public interface IDatabaseFacade
    {
        IPatientsDAO PatientsDAO { get; }

        IDictionaryDAO DictionaryDAO { get; }

        IEmployeesDAO EmployeesDAO { get; }

        IUserDAO UserDAO { get; }

        IOrdersDAO OrderDAO { get; }

        IProfilesDAO ProfilesDAO { get; }

        IStudiesDAO StudiesDAO { get; }

        ISamplesDAO SamplesDAO { get; }

        ITestsDAO TestsDAO { get; }

        IResultUnitsDAO ResultUnitsDAO { get; }

        IVerificationsDAO VerificationsDAO { get; }

        IResultsDAO ResultsDAO { get; }
        //tu wszystkie dao
    }
}
