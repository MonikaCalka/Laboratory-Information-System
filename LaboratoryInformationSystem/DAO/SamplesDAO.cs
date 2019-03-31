using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class SamplesDAO : ISamplesDAO
    {
        public SampleModel ReadSampleById(long id)
        {
            string query = $@"
                select IdSample, IdEmployee, IdStudy, DateOfCollection, Code
                from Samples
                where IdSample = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadSampleModel);
        }

        public List<SampleModel> ReadSamplesList()
        {
            string query = @"
                select IdSample, IdEmployee, IdStudy, DateOfCollection, Code
                from Samples
            ";

            return BaseDAO.Select(query, ReadSampleModel);
        }

        private SampleModel ReadSampleModel(CustomReader reader) {

            EmployeesDAO employee = new EmployeesDAO();
            StudiesDAO study = new StudiesDAO();

            return new SampleModel
            {
                IdSample = reader.GetLong("IdSample"),
                Employee = employee.ReadEmployeeById(reader.GetLong("IdEmployee")),
                Study = study.ReadStudyById(reader.GetLong("IdStudy")),
                DateOfCollecion = reader.GetDate("DateOfCollection"),
                Code = reader.GetString("Code")
            };
        }
    }
}