using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using LaboratoryInformationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    class EmployeesDAO : IEmployeesDAO
    {
        public EmployeeModel ReadEmployeeById(long id)
        {
            string query = $@"
                select IdEmployee, IdPosition, FirstName, Surname, Pesel, Sex, Street, HouseNumber, City, PostalCode, Country, 
                    Phone, Email, DateOfEmployment, DateOfLaying, LicenseNumber, IdWard
                from Employees
                where IdEmployee = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadEmployeeModel);
        }

        public List<EmployeeModel> ReadEmployeesList()
        {
            string query = @"
                select IdEmployee, IdPosition, FirstName, Surname, Pesel, Sex, Street, HouseNumber, City, PostalCode, Country, 
                    Phone, Email, DateOfEmployment, DateOfLaying, LicenseNumber, IdWard
                from Employees
            ";

            return BaseDAO.Select(query, ReadEmployeeModel);
        }

        
        private EmployeeModel ReadEmployeeModel(CustomReader reader)
        {
            DictionaryDAO dict = new DictionaryDAO();

            return new EmployeeModel()
            {
                IdEmployee = reader.GetLong("IdEmployee"),
                Position = dict.ReadDictionaryById(DictionaryTypesEnum.Positions, reader.GetLong("IdPosition"), "pl"),
                FirstName = reader.GetString("FirstName"),
                Surname = reader.GetString("Surname"),
                Pesel = reader.GetString("Pesel"),
                Sex = reader.GetString("Sex"),
                Street = reader.GetString("Street"),
                HouseNumber = reader.GetString("HouseNumber"),
                City = reader.GetString("City"),
                PostalCode = reader.GetString("PostalCode"),
                Country = reader.GetString("Country"),
                Phone = reader.GetString("Phone"),
                Email = reader.GetNullableString("Email"),
                DateOfEmployment = reader.GetDate("DateOfEmployment"),
                DateOfLaying = reader.GetNullableDate("DateOfLaying"),
                LicenseNumber = reader.GetNullableString("LicenseNumber"),
                Ward = dict.ReadDictionaryById(DictionaryTypesEnum.Ward, reader.GetNullableLong("IdWard"), "pl")
            };
        }
    }
}
