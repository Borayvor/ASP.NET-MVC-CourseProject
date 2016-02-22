namespace InteractiveLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using InteractiveLearningSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.CrosswordModels;

    public sealed class Configuration : DbMigrationsConfiguration<InteractiveLearningSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InteractiveLearningSystemDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

                context.SaveChanges();
            }

            if (!context.Languages.Any())
            {
                context.Languages.Add(new Language() { Name = "Bulgarian", CreatedOn = DateTime.UtcNow, IsDeleted = false });
                context.Languages.Add(new Language() { Name = "English", CreatedOn = DateTime.UtcNow, IsDeleted = false });

                context.SaveChanges();
            }
        }
    }
}
