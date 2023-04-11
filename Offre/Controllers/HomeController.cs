using Microsoft.AspNet.Identity;
using Offre.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Details(int jobid)
        {
            var job = db.Jobs.Find(jobid);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["Jobid"] = jobid;
            return View(job);
        }
        [Authorize]
        public ActionResult ApplyJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplyJob(string Message, HttpPostedFileBase UploadFile)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["Jobid"];

            var job = new ApplyForJob1();
            

            var check = db.ApplyForJob1.Where(a => a.Jobid == JobId & a.Userid == UserId).ToList();

            if (check.Count < 1)
            {
                /////////////////////////////
                if (UploadFile != null)
                {
                    var fileName = Path.GetFileName(UploadFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadFile"), UploadFile.FileName);
                    UploadFile.SaveAs(path);
                    job.UploadFile = fileName;

                }
                ///////////////////////////

                job.Userid = UserId;
                job.Message = Message;
                job.ApplyDate = DateTime.Now;
                job.Jobid = JobId;
                db.ApplyForJob1.Add(job);
                db.SaveChanges();
                ViewBag.Result = "Vous avez postulé avec succès pour cette offre";
            }
            else
            {
                ViewBag.Result = "Désolé, j'ai déjà postulé pour cette offre";
            }
            
            return View();
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