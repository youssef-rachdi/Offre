using Microsoft.AspNet.Identity;
using Offre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Offre.Controllers.GstionOffre.GestionRecruteurOffre
{
    [Authorize(Roles = "Recruteur,Admins")]
    public class DashboardRecruteurController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Recruteur

        public ActionResult home()
        {
            return View();
        }

        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var list = db.Jobs
                .Where(p => p.Userid == UserId)
                .ToList();
            return View(list);
        }

        public ActionResult Condidats()
        {
            return View();
        }

        // GET: Recruteur/Details/5
        public ActionResult Condidats(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var JobId = (int)Session["Jobid"];
            var list = db.ApplyForJob1
                .Where(p => p.Jobid == JobId)
                .ToList();
            return View(list);
        }


        // GET: Recruteur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", job.CategoryId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                string OldPath = Path.Combine(Server.MapPath("~/Uploads"), job.JobImage);
                if (Upload != null)
                {
                    System.IO.File.Delete(OldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                    Upload.SaveAs(path);
                    job.JobImage = Upload.FileName;
                }

                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", job.CategoryId);
            return View(job);
        }

        // GET: Recruteur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult DownloadFile(int fileId)
        {
            using (var context = new ApplicationDbContext())
            {
                var file = context.ApplyForJob1.FirstOrDefault(f => f.Id == fileId);
                if (file != null)
                {
                    // Prepare the file for download
                    string filePath = file.UploadFile; // Retrieve the file path from the database
                    string contentType = MimeMapping.GetMimeMapping(filePath); // Determine the file's content type

                    // Return the file as a response
                    return File(filePath, contentType, file.UploadFile);
                }
                else
                {
                    // File not found, handle the error
                    return HttpNotFound();
                }
            }
        }

    }
}
