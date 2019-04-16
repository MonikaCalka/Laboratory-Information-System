using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;

namespace LaboratoryInformationSystem.DAO
{
    public class ResultsDAO : IResultsDAO
    {
        public ResultModel ReadResultById(long id)
        {
            string query = $@"
                select IdResult, IdEmployee, IdStudy, DateOfResult, Description, ReasonForRepeat, Actual
                from Results
                where IdResult = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadResultModel);
        }

        public List<ResultModel> ReadResultsList()
        {
            string query = @"
                select IdResult, IdEmployee, IdStudy, DateOfResult, Description, ReasonForRepeat, Actual
                from Results
            ";

            return BaseDAO.Select(query, ReadResultModel);
        }

        private ResultModel ReadResultModel(CustomReader reader)
        {
            return new ResultModel()
            {
                IdResult = reader.GetLong("IdResult"),
                IdEmployee = reader.GetLong("IdEmployee"),
                IdStudy = reader.GetLong("IdStudy"),
                DateOfResult = reader.GetDate("DateOfResult"),
                Description = reader.GetNullableString("Description"),
                ReasonForRepeat = reader.GetNullableString("ReasonForRepeat"),
                Actual = reader.GetBool("Actual")
            };
        }
    }
}
