using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Offre.Controllers.GstionOffre.GestionAdminOffre
{
    public class DashboardAdmintController : Controller
    {
        // GET: DashboardAdmint
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardAdmint/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
