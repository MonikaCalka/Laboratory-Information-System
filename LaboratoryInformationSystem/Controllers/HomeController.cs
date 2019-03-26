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
            PatientModel Janeczek = DB.PatientsDAO.ReadPatientById(1);
            
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