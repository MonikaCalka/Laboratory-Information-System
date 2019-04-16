using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryInformationSystem.Models;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IVerificationsDAO
    {
        List<VerificationModel> ReadVerificationsList();
        VerificationModel ReadVerificationById(long id);
        VerificationModel ReadVerificationByResultId(long id);
    }
}
