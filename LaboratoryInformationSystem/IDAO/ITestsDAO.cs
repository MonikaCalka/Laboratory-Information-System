using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface ITestsDAO
    {
        List<TestModel> ReadTestsList(string lang);
        TestModel ReadTestById(long id, string lang);

        List<TestModel> ReadOrderedTestsList(long idStudy, string lang);
        TestModel ReadOrderedTestById(long idOrderedTest, string lang);
    }
}