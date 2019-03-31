using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class TestsDAO : ITestsDAO
    {
        public TestModel ReadTestById(long id, string lang)
        {
            string query = $@"
                select t.IdTest, t.IdProfile, t.Code, t.NormMinM, t.NormMaxM, t.NormMinF, t.NormMaxF, tr.Name as Name
                from Tests t
                join TestTranslations tr on t.IdTest = tr.IdTest
                join Languages l on tr.IdLanguage = l.IdLanguage
                where t.IdTest = {id} and l.code = '{lang}'
            ";

            return BaseDAO.SelectFirst(query, ReadTestModel);
        }

        public List<TestModel> ReadTestsList(string lang)
        {
            string query = $@"
                select t.IdTest, t.IdProfile, t.Code, t.NormMinM, t.NormMaxM, t.NormMinF, t.NormMaxF, tr.Name as Name
                from Tests t
                join TestTranslations tr on t.IdTest = tr.IdTest
                join Languages l on tr.IdLanguage = l.IdLanguage
                where l.code = '{lang}'
            ";

            return BaseDAO.Select(query, ReadTestModel);
        }

        private TestModel ReadTestModel(CustomReader reader) {

            IProfilesDAO profile = new ProfilesDAO();

            return new TestModel
            {
                IdTest = reader.GetLong("IdTest"),
                Profile = profile.ReadProfileById(reader.GetLong("IdProfile"), "pl"),
                Code = reader.GetString("Code"),
                NormMinM = reader.GetDouble("NormMinM"),
                NormMaxM = reader.GetDouble("NormMaxM"),
                NormMinF = reader.GetDouble("NormMinF"),
                NormMaxF = reader.GetDouble("NormMaxF"),
                Name = reader.GetString("Name")
            };
        }
    }
}