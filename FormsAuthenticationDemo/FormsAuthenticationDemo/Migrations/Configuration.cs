namespace FormsAuthenticationDemo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FormsAuthenticationDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FormsAuthenticationDemo.Models.ApplicationDbContext";
        }

        protected override void Seed(FormsAuthenticationDemo.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(new IdentityRole("Admins"));
            roleManager.Create(new IdentityRole("Guests"));


            if (!(context.Users.Any(u => u.UserName == "Admin@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Admin@Company.com", PhoneNumber = "1234567890" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Admins");
            }

            if (!(context.Users.Any(u => u.UserName == "Guest@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Guest@Company.com", PhoneNumber = "1234567891" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Guests");
            }
        }
    }
}
