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

        public ActionResult job_location_info()
        {
            var getlocation = db.Job_location.ToList();
            return View(getlocation);
        }

        public ActionResult JobSeeker()
        {
            var getjobseeker = db.jobseeker_tb.ToList();
            return View(getjobseeker);
        }

        public ActionResult Details(int id)
        {
            var getdetails = db.jobseeker_tb.Where(x=>x.JS_ID==id).FirstOrDefault();

            return PartialView(getdetails);
        }

        //Detail page
        public ActionResult Detail(int id)
        {
            var getdetails = db.jobseeker_tb.Find(id);

            return View(getdetails);
        }

        
    }
}