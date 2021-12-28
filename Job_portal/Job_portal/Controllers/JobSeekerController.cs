using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_portal.Models;

namespace Job_portal.Controllers
{
    public class JobSeekerController : Controller
    {
        Job_DatabaseEntities db = new Job_DatabaseEntities();

        // GET: JobSeeker
        public ActionResult Index()
        {
            try
            {
                Response.Cache.SetNoStore();
                TempData["jobseekername"] = Session["jobseekerusername"].ToString();
            }
            catch (Exception ex)
            {
                ViewBag.ss = ex.ToString();
                return RedirectToAction("login","Home");
            }
            return View();
        }

        public ActionResult JobSeeker()
        {
            int jid = Convert.ToInt32(Session["jsid"]);
            var listjobs = db.jobseeker_tb.Where(x => x.JS_ID == jid).ToList();
            return View(listjobs);
        }

        public ActionResult jobseekerDetail(int id)
        {
            var getjobseeker = db.jobseeker_tb.Find(id);
            return View(getjobseeker);
        }

        public ActionResult EducAtionInfo()
        {
            int jid = Convert.ToInt32(Session["jsid"]);
            var listeducation = db.Education_tb.Where(x => x.Job_seeker_ID== jid).ToList();
            return View(listeducation);
        }

        //Education Detail in popup
        public ActionResult EducationDetail(int id)
        {
            var geteduction = db.Education_tb.Find(id);
            return View(geteduction);
        }

        public ActionResult ApplyJobStatus()
        {
            int jid = Convert.ToInt32(Session["jsid"]);
            var listapplyjob = db.ApplyJob_tb.Where(x => x.Job_seekerID == jid).ToList();
            
            ViewBag.p = listapplyjob;
            return View();


        }

        public ActionResult DownloadResume(int id)
        {

            var a = db.Education_tb.Where(x => x.Job_seeker_ID == id).ToList();
            //var getdetails = db.Education_tb.Find(id);
            ViewBag.p = a;
            return View();
        }


    }
}