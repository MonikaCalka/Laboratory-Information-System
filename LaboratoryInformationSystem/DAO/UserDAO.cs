using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class UserDAO : IUserDAO
    {
        public UserModel ReadUserById(long id)
        {
            string query = $@"
                select IdUser, IdEmployee, Login, Password, DateOfChange, InUse
                from Users
                where IdUser = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadUserModel);
        }

        public List<UserModel> ReadUsersList()
        {
            string query = @"
                select IdUser, IdEmployee, Login, Password, DateOfChange, InUse
                from Users
            ";

            return BaseDAO.Select(query, ReadUserModel);
        }

        private UserModel ReadUserModel(CustomReader reader)
        {
            EmployeesDAO employee = new EmployeesDAO();
            return new UserModel()
            {
                IdUser = reader.GetLong("IdUser"),
                Employee = employee.ReadEmployeeById(reader.GetLong("IdEmployee")),
                Login = reader.GetString("Login"),
                Password = reader.GetString("Password"),
                DateOfChange = reader.GetDate("DateOfChange"),
                InUse = reader.GetBool("InUse")
            };
        }
    }
}