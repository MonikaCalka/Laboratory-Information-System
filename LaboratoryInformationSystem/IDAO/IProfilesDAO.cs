using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IProfilesDAO
    {
        List<ProfileModel> ReadProfilesList(string lang);
        ProfileModel ReadProfileById(long? id, string lang);
    }
}
