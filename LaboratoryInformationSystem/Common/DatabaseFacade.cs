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

        public IDictionaryDAO DictionaryDAO { get; private set; }

        public IEmployeesDAO EmployeesDAO { get; private set; }

        public IUserDAO UserDAO { get; private set; }

        public DatabaseFacade()
        {
            PatientsDAO = new PatientsDAO();

            DictionaryDAO = new DictionaryDAO();

            EmployeesDAO = new EmployeesDAO();

            UserDAO = new UserDAO();
        }
    }
}