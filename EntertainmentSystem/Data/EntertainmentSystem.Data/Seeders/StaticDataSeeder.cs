namespace EntertainmentSystem.Data.Seeders
{
    using System.Linq;
    using EntertainmentSystem.Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Forum;

    internal static class StaticDataSeeder
    {
        internal static void SeedRoles(EntertainmentSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var administratorRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
            roleManager.Create(administratorRole);

            var moderatorRole = new IdentityRole { Name = GlobalConstants.ModeratorRoleName };
            roleManager.Create(moderatorRole);

            context.SaveChanges();
        }

        internal static void SeedUsers(EntertainmentSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorFirstName = "Admincho";
            const string AdministratorLastName = "Adminov";
            const string AdministratorPassword = "admin";

            // Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser
            {
                UserName = AdministratorUserName,
                Email = AdministratorUserName,
                FirstName = AdministratorFirstName,
                LastName = AdministratorLastName
            };

            userManager.PasswordValidator = new MinimumLengthValidator(GlobalConstants.PasswordMinLength);
            userManager.Create(user, AdministratorPassword);

            // Assign user to admin role
            userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

            context.SaveChanges();
        }

        internal static void SeedPostCategories(EntertainmentSystemDbContext context)
        {
            if (context.PostCategories.Any())
            {
                return;
            }

            var category = new PostCategory
            {
                Name = "Unknown"
            };

            context.PostCategories.Add(category);
            context.SaveChanges();
        }

        internal static void SeedPosts(EntertainmentSystemDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var post = new Post
            {
                Title = "dfjdas",
                Content = "jdskouiqweioqwueqwiopeqwiowe o9qweuqwoeq",
                AuthorId = context.Users.FirstOrDefault().Id,
                PostCategoryId = context.PostCategories.FirstOrDefault().Id,
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }

        internal static void SeedTags(EntertainmentSystemDbContext context)
        {
            if (context.PostTags.Any())
            {
                return;
            }

            var tag = new PostTag
            {
                Name = "Unknown",
                Posts = context.Posts.ToList()
            };

            context.PostTags.Add(tag);
            context.SaveChanges();
        }
    }
}
