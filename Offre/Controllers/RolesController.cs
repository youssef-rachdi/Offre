using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Offre.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(Db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = Db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
           
                if (ModelState.IsValid)
                {
                    Db.Roles.Add(role);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(role);
           
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = Db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(role).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = Db.Roles.Find(id);
            if (role ==null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            try
            {
                var Myroles = Db.Roles.Find(role.Id);
                Db.Roles.Remove(Myroles);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(role);
            }
        }
    }
}
