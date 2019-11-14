namespace ExcellentTaste.Migrations.ApplicationDbContext
{
    using ExcellentTaste.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExcellentTaste.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
        }

        protected override void Seed(ExcellentTaste.Models.ApplicationDbContext context)
        {

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string userRoles in Enum.GetNames(typeof(UserType)))
            {
                var applicationRoleAdministrator = new IdentityRole { Name = userRoles };
                if (!roleManager.RoleExists(applicationRoleAdministrator.Name))
                {
                    roleManager.Create(applicationRoleAdministrator);
                }
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
