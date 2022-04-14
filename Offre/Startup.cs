using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        private ApplicationDbContext Db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Db));
            var userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Db));
            IdentityRole role = new IdentityRole();
            if (!roleManger.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManger.Create(role);
                ApplicationUser User = new ApplicationUser();
                User.UserName = "Rachdi";
                User.Email = "rachdiy03@gmail.com";
                var check = userManger.Create(User, "GalaxyJ7@");
                if (check.Succeeded)
                {
                    userManger.AddToRole(User.Id, "Admins");
                }
            }

        }
    }
}
