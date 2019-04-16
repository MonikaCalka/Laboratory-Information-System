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
            return new OrderModel()
            {
                IdOrder = reader.GetLong("IdOrder"),
                IdPatient = reader.GetLong("IdPatient"),
                IdEmployee = reader.GetLong("IdEmployee"),
                IdWard = reader.GetNullableLong("IdWard"),
                Institution = reader.GetNullableString("Institution"),
                Comment = reader.GetNullableString("Comment"),
                DateOfOrder = reader.GetDate("DateOfOrder"),
                DateOfReceived = reader.GetNullableDate("DateOfReceived"),
                IdStatus = reader.GetLong("IdStatus"),
                IdPriority = reader.GetLong("IdPriority")
            };
        }
    }
}