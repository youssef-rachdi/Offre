using System.Web.Mvc;
using WebApplication2.Models;
using System.Linq;
using Microsoft.AspNet.Identity;
using Offre.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Configuration;
using WebApplication2;

namespace Offre.Controllers.GstionOffre.GestionAdminOffre
{
    [Authorize(Roles = "Admins")]
    public class DashboardAdmintController : Controller
    {

        ApplicationDbContext db;
        // GET: DashboardAdmint
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardAdmint/Details/5
        public ActionResult Statistique()
        {
            using (var db1 = new ApplicationDbContext())
            {
                int jobCount = db1.Jobs.Count();
                ViewBag.JobCount = jobCount;
            }
            

            var db = new ApplicationDbContext();
            var counts = db.Jobs.Include(p => p.Category)
                                 .GroupBy(p => p.Category.CategoryName)
                                 .Select(g => new MyViewModel
                                 {
                                     Category = g.Key,
                                     CategoryCount = g.Count()
                                 }).ToList();


            return View(counts);
        }


        // GET: DashboardAdmint/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardAdmint/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardAdmint/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardAdmint/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardAdmint/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardAdmint/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
