namespace Grocery2Go.Migrations
{
    using Grocery2Go.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Grocery2Go.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<Role> roleStore = new RoleStore<Role>(context);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new ApplicationUserManager(userStore);
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new ApplicationRoleManager(roleStore);

            // Ensure Admin role
            if (!roleManager.RoleExists("Vendor"))
            {
                roleManager.Create(new Role { Name = "Vendor" });

            }
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new Role { Name = "User" });

            }

            // Ensure Jason
            ApplicationUser jason = userManager.FindByName("jasmathi86@gmail.com");
            if (jason == null)
            {
                jason = new ApplicationUser
                {
                    Email = "jasmathi86@gmail.com",
                    UserName = "jasmathi86@gmail.com"

                };
                userManager.Create(jason, "password");
                userManager.AddToRole(jason.Id, "Vendor");

                jason = userManager.FindByName("jasmathi86@gmail.com");
            }
        }
    }
}
