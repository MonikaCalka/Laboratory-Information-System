using LaboratoryInformationSystem.DAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratoryInformationSystem.Controllers
{
    public class HomeController : CustomController
    {
        public ActionResult Index()
        {
            
            List<PatientModel> list = DB.PatientsDAO.ReadPatientsList();
            PatientModel Janeczek = DB.PatientsDAO.ReadPatientById(1L);

            DictionaryModel dic = DB.DictionaryDAO.ReadDictionaryById(Enums.DictionaryTypesEnum.Positions, 1L, "pl");
            List<DictionaryModel> dicList = DB.DictionaryDAO.ReadDictionaryListByType(Enums.DictionaryTypesEnum.Positions, "pl");

            DictionaryModel dic2 = DB.DictionaryDAO.ReadDictionaryById(Enums.DictionaryTypesEnum.Ward, 1L, "en");
            List<DictionaryModel> dicList2 = DB.DictionaryDAO.ReadDictionaryListByType(Enums.DictionaryTypesEnum.Ward, "en");

            DictionaryModel dic3 = DB.DictionaryDAO.ReadDictionaryById(Enums.DictionaryTypesEnum.Status, 1L, "pl");
            List<DictionaryModel> dicList3 = DB.DictionaryDAO.ReadDictionaryListByType(Enums.DictionaryTypesEnum.Status, "pl");

            DictionaryModel dic4 = DB.DictionaryDAO.ReadDictionaryById(Enums.DictionaryTypesEnum.Priorities, 1L, "en");
            List<DictionaryModel> dicList4 = DB.DictionaryDAO.ReadDictionaryListByType(Enums.DictionaryTypesEnum.Priorities, "en");

            List<EmployeeModel> empList = DB.EmployeesDAO.ReadEmployeesList();
            EmployeeModel emp = DB.EmployeesDAO.ReadEmployeeById(1L);

            List<UserModel> userList = DB.UserDAO.ReadUsersList();
            UserModel user = DB.UserDAO.ReadUserById(2L);
            return View();
            //return Json(Janeczek, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}