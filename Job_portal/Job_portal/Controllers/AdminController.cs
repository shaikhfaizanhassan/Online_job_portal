using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_portal.Models;
namespace Job_portal.Controllers
{
    public class AdminController : Controller
    {
        Job_DatabaseEntities db = new Job_DatabaseEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult job_cat_info()
        {
            var getjob_cat = db.job_categorytb.ToList();
            return View(getjob_cat);
        }

    }
}