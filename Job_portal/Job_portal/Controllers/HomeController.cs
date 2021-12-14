using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_portal.Models;
namespace Job_portal.Controllers
{
    public class HomeController : Controller
    {
        Job_DatabaseEntities db = new Job_DatabaseEntities();
        public ActionResult Index()
        {
            var jobshow = db.PostJob_tb.ToList();
            ViewBag.showjob = jobshow;
            return View();
        }


     

    }
}