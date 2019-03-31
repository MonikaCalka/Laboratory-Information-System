using LaboratoryInformationSystem.Enums;
using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class StudiesDAO : IStudiesDAO
    {
        public StudyModel ReadStudyById(long? id)
        {
            string query = $@"
                select IdStudy, IdProfile, IdEmployee, IdOrder, IdStatus, DateOfStudy
                from Studies
                where IdStudy = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadStudyModel);
        }

        public List<StudyModel> ReadStudiesList()
        {
            string query = @"
                select IdStudy, IdProfile, IdEmployee, IdOrder, IdStatus, DateOfStudy
                from Studies
            ";

            return BaseDAO.Select(query, ReadStudyModel);
        }

        private StudyModel ReadStudyModel(CustomReader reader)
        {
            DictionaryDAO dict = new DictionaryDAO();
            EmployeesDAO employee = new EmployeesDAO();
            ProfilesDAO profile = new ProfilesDAO();
            OrdersDAO order = new OrdersDAO();

            return new StudyModel()
            {
                IdStudy = reader.GetLong("IdStudy"),
                Profile = profile.ReadProfileById(reader.GetLong("IdProfile"), "pl"),
                Employee = employee.ReadEmployeeById(reader.GetLong("IdEmployee")),
                Order = order.ReadOrderById(reader.GetLong("IdOrder")),
                Status = dict.ReadDictionaryById(DictionaryTypesEnum.Status, reader.GetLong("IdStatus"), "pl"),
                DateOfStudy = reader.GetDate("DateOfStudy")
            };
        }
    }
}