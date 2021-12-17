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
            var applyjobstatus = db.ApplyJob_tb.ToList();

            ViewBag.showjob = jobshow;
            ViewBag.applystatuscheck = applyjobstatus;

            return View();
        }
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(jobseeker_tb usr)
        {

            var a = db.jobseeker_tb.Where(l => l.UserName == usr.UserName && l.Password == usr.Password).FirstOrDefault();
            if (a != null)
            {
                Session["jsid"] = a.JS_ID.ToString();
                return RedirectToAction("index", "JobSeeker");
            }
            else
            {
                ViewBag.msg = "Invalid User Name or Password";
            }
            return View();
        }
        public ActionResult logout()
        {

            Session.Abandon();
            Session.Remove("jsid");
            Session.RemoveAll();

            return RedirectToAction("login", "Home");
        }
        [HttpPost]
        public ActionResult Apply(ApplyJob_tb ap, string JobID, string Company_ID, string Job_seekerID)
        {
            int a = 1;
            ApplyJob_tb obj = new ApplyJob_tb();
            obj.JobID = ap.JobID;
            obj.Job_seekerID = ap.Job_seekerID;
            obj.Company_ID = ap.Company_ID;
            obj.Status = Convert.ToInt32(a).ToString();
            obj.EntryDate = DateTime.Now;
            db.ApplyJob_tb.Add(obj);
            db.SaveChanges();
            return RedirectToAction("ConfirmApplyJob");
        }

        public ActionResult ConfirmApplyJob()
        {
            return View();
        }

        //public ActionResult DownloadResume(int id)
        //{
        //    var getdetails = db.Education_tb.Find(id);
        //    return View(getdetails);
        //}
        ////edit company details
        //public ActionResult DownloadResume()
        //{
        //    var getcompanyedit = db.Education_tb.Where(x => x.Job_seeker_ID == x.Job_seeker_ID).FirstOrDefault();
        //    return View(getcompanyedit);
        //}
        ////public ActionResult DownloadResume(int id)
        //{
        //    //int josid = Convert.ToInt32(Session["jsid"]);


        //    var josids = db.Education_tb.Where(x => x.Job_seeker_ID == id).ToList();


        //    return View(josids);
        //}

        //[HttpPost]
        //public ActionResult DownloadResume(int id)
        //{
        //    int josid = Convert.ToInt32(Session["jsid"]);
        //    var d = db.Education_tb.Where(x => x.Job_seeker_ID == josid).FirstOrDefault();
        //    return View(d);
        //}


    }
}