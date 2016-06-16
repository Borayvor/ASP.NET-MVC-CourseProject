namespace EntertainmentSystem.Data.Seeders
{
    using System.Collections.Generic;
    using System.Linq;
    using EntertainmentSystem.Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Forum;
    using Models.Media;

    internal static class StaticDataSeeder
    {
        private static readonly List<int> MediaCetegoriesId = new List<int>();

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

        internal static void SeedMediaCategory(EntertainmentSystemDbContext context)
        {
            if (context.MediaCategories.Any())
            {
                return;
            }

            var category = new MediaCategory
            {
                Name = "Action"
            };

            context.MediaCategories.Add(category);
            context.SaveChanges();
        }

        internal static void SeedMediaContents(EntertainmentSystemDbContext context)
        {
            if (context.MediaContents.Any())
            {
                return;
            }

            var contentPicture = new MediaContent
            {
                Title = "Test Picture",
                ContentType = ContentType.Picture,
                ContentUrl = "http://i2.wp.com/www.cgmeetup.net/home/wp-content/uploads/2015/11/World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg?resize=960%2C398",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture);

            var contentMusic = new MediaContent
            {
                Title = "Test Music",
                ContentType = ContentType.Sound,
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/4jji3780sr8r1s6/Apps/EntertainmentSystem/9dc6074e-c2e1-4c27-8afa-43d6ecefc2ef",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic);

            var contentVideo = new MediaContent
            {
                Title = "Test Video",
                ContentType = ContentType.Video,
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/bodhvtk84cgs1js/Apps/EntertainmentSystem/73d967bc-9053-487c-bc3b-2a2ab44b2bab.mp4",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo);

            context.SaveChanges();
        }
    }
}
