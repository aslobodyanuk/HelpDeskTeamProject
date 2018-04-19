using HelpDeskTeamProject.Context;
using HelpDeskTeamProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpDeskTeamProject.Startup))]
namespace HelpDeskTeamProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void CreateAdmin()
        {
            AppContext dbContext = new AppContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
  
            if (!roleManager.RoleExists("Admin"))
            { 
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);                

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";

                string userPass = "A@Z200711";

                var checkUser = UserManager.Create(user, userPass);

                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
