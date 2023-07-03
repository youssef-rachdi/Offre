using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Offre.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Offre.Controllers.GstionOffre.GestionAdminOffre
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        public async Task<ActionResult> IndexUsers()
        {
           
            return View();
        }
    }
}