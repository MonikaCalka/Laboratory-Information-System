using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaboratoryInformationSystem.DAO;
using LaboratoryInformationSystem.IDAO;

namespace LaboratoryInformationSystem.Common
{
    public class DatabaseFacade : IDatabaseFacade
    {
        public IPatientsDAO PatientsDAO { get; private set; }

        public DatabaseFacade()
        {
            PatientsDAO = new PatientsDAO();
        }
    }
}