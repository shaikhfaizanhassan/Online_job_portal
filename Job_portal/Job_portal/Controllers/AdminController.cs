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
        
        public ActionResult Loginset(admin_tb adtb)
        {
            try
            {
                var admin_login = db.admin_tb.Where(x => x.Email == adtb.Email && x.Password == adtb.Password).FirstOrDefault();
                if (admin_login != null)
                {
                    Session["adminemail"] = admin_login.UserName.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Eror"] = "Login Failed";
                    return RedirectToAction("Login", "Admin");
                }
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
                return RedirectToAction("Login", "Admin");
            }            
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

        //edit company details
        public ActionResult EditCompnayDetail(int id)
        {
            var getcompanyedit = db.Company_tb.Where(x => x.CID == id).FirstOrDefault();
            return View(getcompanyedit);
        }
        [HttpPost]
        public ActionResult EditCompnayDetail(Company_tb comptb)
        {
            if(ModelState.IsValid)
            {
                db.Entry(comptb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CompanyInfo","Admin");
            }
            return View();
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

        //edit Job seeker Profile
        public ActionResult JobseekerEdit(int id)
        {
            var getjobseekereditdata = db.jobseeker_tb.Where(x => x.JS_ID == id).FirstOrDefault();
            return View(getjobseekereditdata);
        }

        [HttpPost]
        public ActionResult JobseekerEdit(jobseeker_tb jobseeker)
        {
            if(ModelState.IsValid)
            {
                db.Entry(jobseeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("JobSeeker", "Admin");
            }
            return View();
        }



    }
}