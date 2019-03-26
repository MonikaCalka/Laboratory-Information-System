using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryInformationSystem.IDAO
{
    public interface IUserDAO
    {
        List<UserModel> ReadUsersList();
        UserModel ReadUserById(long id);
    }
}
