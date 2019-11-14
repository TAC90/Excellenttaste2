using System;
using ExcellentTaste.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcellentTaste.Startup))]
namespace ExcellentTaste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                var user = userManager.FindByEmail("Admin@admin.com");
                userManager.AddToRole(user.Id, "Admin");
            }
            catch (System.Exception)
            {
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.UserType = UserType.Admin;
                string pwd = "Admin.123";
                var checkUser = userManager.Create(user, pwd);
                //if (checkUser.Succeeded)
                //{
                //    userManager.AddToRole(user.Id, "Administrator");
                //}
                //else
                //{
                //    throw;
                //}
            }
        }
    }
}
