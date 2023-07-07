using Offre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Offre.Controllers.GstionOffre.GestionRecruteurOffre
{
    public class CondidatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Condidats
        public ActionResult Index()
        {
            //var JobId = (int)Session["Jobid"];
            //var list = db.ApplyForJob1
            //    .Where(p => p.Jobid == JobId)
            //    .Select(p => new ConadidatsViewModel
            //    {
            //        Id = p.Id,
            //        Message = p.Message,
            //        ApplyDate = p.ApplyDate

            //    })
            //    .ToList();
            //return View(list);
            //var con = db.ApplyForJob1.ToList();
            return View();
        }
    }
}