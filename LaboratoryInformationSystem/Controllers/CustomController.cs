using LaboratoryInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratoryInformationSystem.Controllers
{
    public class CustomController : Controller
    {
        //tu to co ma być w każdym controllerze
        protected IDatabaseFacade DB;

        public CustomController()
        {
            DB = new DatabaseFacade();
        }
    }
}