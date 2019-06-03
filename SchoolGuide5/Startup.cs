using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolGuide5.Models;


[assembly: OwinStartupAttribute(typeof(SchoolGuide5.Startup))]
namespace SchoolGuide5
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateRoles();
            CreateUsers();

        }
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "Admin@gmail.com";
            user.UserName = "Admin1234";
            var check = userManager.Create(user, "Admin_1234");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateRoles()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);


            }
            if (!roleManager.RoleExists("Parents"))
            {
                role = new IdentityRole();
                role.Name = "Parents";
                roleManager.Create(role);

            }
        }


    }
}
