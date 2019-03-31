using LaboratoryInformationSystem.Enums;
using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class OrdersDAO : IOrdersDAO
    {
        public OrderModel ReadOrderById(long id)
        {
            string query = $@"
                select IdOrder, IdPatient, IdEmployee, IdWard, Institution, Comment, DateOfOrder, DateOfReceived, IdStatus,
                    IdPriority
                from Orders
                where IdOrder = {id}
            ";

            return BaseDAO.SelectFirst(query, ReadOrderModel);
        }

        public List<OrderModel> ReadOrdersList()
        {
            string query = @"
                select IdOrder, IdPatient, IdEmployee, IdWard, Institution, Comment, DateOfOrder, DateOfReceived, IdStatus,
                    IdPriority
                from Orders
            ";

            return BaseDAO.Select(query, ReadOrderModel);
        }


        private OrderModel ReadOrderModel(CustomReader reader)
        {
            DictionaryDAO dict = new DictionaryDAO();
            PatientsDAO patient = new PatientsDAO();
            EmployeesDAO employee = new EmployeesDAO();

            return new OrderModel()
            {
                IdOrder = reader.GetLong("IdOrder"),
                Patient = patient.ReadPatientById(reader.GetLong("IdPatient")),
                Employee = employee.ReadEmployeeById(reader.GetLong("IdEmployee")),
                Ward = dict.ReadDictionaryById(DictionaryTypesEnum.Ward, reader.GetNullableLong("IdWard"), "pl"),
                Institution = reader.GetNullableString("Institution"),
                Comment = reader.GetNullableString("Comment"),
                DateOfOrder = reader.GetDate("DateOfOrder"),
                DateOfReceived = reader.GetNullableDate("DateOfReceived"),
                Status = dict.ReadDictionaryById(DictionaryTypesEnum.Status, reader.GetNullableLong("IdStatus"), "pl"),
                Priority = dict.ReadDictionaryById(DictionaryTypesEnum.Priorities, reader.GetNullableLong("IdPriority"), "pl"),
                Consultants = employee.ReadConsultantsList(reader.GetLong("IdOrder"))
            };
        }
    }
}