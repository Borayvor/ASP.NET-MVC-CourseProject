namespace EntertainmentSystem.Data.Seeders
{
    using System.Linq;
    using EntertainmentSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal static class StaticDataSeeder
    {
        internal static void SeedUsers(EntertainmentSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

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
    }
}
