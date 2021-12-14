using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //public ActionResult Details(int id)
        //{
        //    var getdetails = db.jobseeker_tb.Where(x=>x.JS_ID==id).FirstOrDefault();

        //    return PartialView(getdetails);
        //}


        //Detail page ss
        public ActionResult Detail(int id)
        {
            var getdetails = db.jobseeker_tb.Find(id);

            return View(getdetails);
        }


        //Company Details
        public ActionResult CompanyInfo()
        {
            var getcompanyinfo = db.Company_tb.ToList();
            return View(getcompanyinfo);
        }

        //company detail popup
        public ActionResult CompanyDetail(int id)
        {
            var getdetails = db.Company_tb.Find(id);
            return View(getdetails);
        }

        //Education Details
        public ActionResult EducAtionInfo()
        {
            var geteduction = db.Education_tb.ToList();
            return View(geteduction);
        }

        //Education Detail in popup
        public ActionResult EducationDetail(int id)
        {
            var geteduction = db.Education_tb.Find(id);
            return View(geteduction);
        }

        public ActionResult checkPostedJob()
        {
            var get_posted_job = db.PostJob_tb.ToList();
            return View(get_posted_job);
        }

        //posted job detail popup
        public ActionResult JobPostedDetail(int id)
        {
            var getpostedjob = db.PostJob_tb.Find(id);
            return View(getpostedjob);
            
        }
        //admin can Activate deactivate
        public ActionResult PostedJobEdit(int id)
        {
            var editpostedjob = db.PostJob_tb.Where(x=>x.JobID==id).FirstOrDefault();
            return View(editpostedjob);
        }
        [HttpPost]
        public ActionResult PostedJobEdit(PostJob_tb pj)
        {
            if(ModelState.IsValid)
            {
                db.Entry(pj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("checkPostedJob","Admin");
            }
            return View(pj);
        }



    }
}