using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Offre.Models;
using WebApplication2.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Web.WebPages;

namespace Offre.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Category);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        [Authorize(Roles = "Admins")]
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

        // GET: Jobs/Create
        [Authorize(Roles = "Recruteur,Admins")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Recruteur,Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(Job job, HttpPostedFileBase Upload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var UserId = User.Identity.GetUserId();
        //        string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);

        //        Upload.SaveAs(path);

        //        job.Userid= UserId;
        //        job.JobImage = Upload.FileName;
        //        db.Jobs.Add(job);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }

        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", job.CategoryId);
        //    return View(job);
        //}


        public ActionResult Create(Job job, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                var UserId = User.Identity.GetUserId();

                // Check if a file was uploaded
                if (Upload != null && Upload.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                    Upload.SaveAs(path);
                    job.JobImage = Upload.FileName;
                }
                else
                {
                    // If no file was uploaded, set a default image path
                    job.JobImage = "offredemploi_.jpg"; // Replace "default_image.jpg" with the path of your default image
                }

                job.Userid = UserId;
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", job.CategoryId);
            return View(job);
        }


        // GET: Jobs/Edit/5
        [Authorize(Roles = "Admins")]
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
        [Authorize(Roles = "Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                string OldPath = Path.Combine(Server.MapPath("~/Uploads"), job.JobImage);
                if (Upload !=null)
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

        // GET: Jobs/Delete/5
        [Authorize(Roles = "Admins")]
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

        // POST: Jobs/Delete/5
        [Authorize(Roles = "Admins")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
