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
            var jobcat = db.job_categorytb.ToList();


            ViewBag.showjob = jobshow;
            ViewBag.applystatuscheck = applyjobstatus;

            ViewBag.jobcatshow = jobcat;

            return View();
        }
        public ActionResult login()
        {
            try
            {
                Response.Cache.SetNoStore();
                if (Session["jsid"].ToString() != null)
                {
                    return RedirectToAction("Index", "JobSeeker");
                }
                else
                {
                    return RedirectToAction("login", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
                return View();
            }
        }
        [HttpPost]
        public ActionResult login(jobseeker_tb usr)
        {
            try
            {
                var a = db.jobseeker_tb.Where(l => l.UserName == usr.UserName && l.Password == usr.Password).SingleOrDefault();
                if (a != null)
                {
                    Session["jsid"] = a.JS_ID.ToString();
                    ViewBag.jstatus = "not applied";
                    Session["jobseekerusername"] = a.FirstName.ToString();

                    return RedirectToAction("index", "JobSeeker");
                }
                else
                {
                    ViewBag.msg = "Invalid User Name or Password";
                    return RedirectToAction("login", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.s = ex.ToString();
                return RedirectToAction("login", "Home");
            }
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
        //Today 7 feb 2021

    }
}