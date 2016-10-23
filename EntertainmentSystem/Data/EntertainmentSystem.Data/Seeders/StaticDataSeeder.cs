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
            const string AdministratorImageUrl = "http://vignette4.wikia.nocookie.net/marveldatabase/images/4/41/Boreas_0001.jpg/revision/latest?cb=20110201173602";

            const string ModeratorUserName = "moderator@moderator.com";
            const string ModeratorFirstName = "Gosho";
            const string ModeratorLastName = "Peshev";
            const string ModeratorPassword = "moderator";
            const string ModeratorImageUrl = "http://batman-news.com/wp-content/uploads/2014/01/logo-snb.png";

            // Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userAdmin = new ApplicationUser
            {
                UserName = AdministratorUserName,
                Email = AdministratorUserName,
                FirstName = AdministratorFirstName,
                LastName = AdministratorLastName,
                ImageUrl = AdministratorImageUrl
            };

            userManager.PasswordValidator = new MinimumLengthValidator(GlobalConstants.PasswordMinLength);
            userManager.Create(userAdmin, AdministratorPassword);

            // Assign user to admin role
            userManager.AddToRole(userAdmin.Id, GlobalConstants.AdministratorRoleName);

            // Create moderator user
            var userModerator = new ApplicationUser
            {
                UserName = ModeratorUserName,
                Email = ModeratorUserName,
                FirstName = ModeratorFirstName,
                LastName = ModeratorLastName,
                ImageUrl = ModeratorImageUrl
            };

            userManager.PasswordValidator = new MinimumLengthValidator(GlobalConstants.PasswordMinLength);
            userManager.Create(userModerator, ModeratorPassword);

            // Assign user to moderator role
            userManager.AddToRole(userModerator.Id, GlobalConstants.ModeratorRoleName);

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

            // add pictures
            var contentPicture_1 = new MediaContent
            {
                Title = "Legion",
                Description = "kjdiouiow fsdiodasp",
                ContentUrl = "http://i2.wp.com/www.cgmeetup.net/home/wp-content/uploads/2015/11/World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg?resize=960%2C398",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_1);

            var contentPicture_2 = new MediaContent
            {
                Title = "Warcraft movie",
                Description = "totireo cxlkjasda",
                ContentUrl = "http://blogs-images.forbes.com/scottmendelson/files/2016/05/Warcraft-Movie-Mobile-Wallpapers-1200x675.jpg",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_2);

            var contentPicture_3 = new MediaContent
            {
                Title = "garona",
                Description = "weqe cposp[d",
                ContentUrl = "http://www.hdwallpapers.in/download/garona_warcraft_movie-720x1280.jpg",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_3);

            // add music
            var contentMusic_1 = new MediaContent
            {
                Title = "if i could fly",
                Description = "helloween-if_i_could_fly.mp3",
                ContentUrl = "http://tones.mob.org/ringtone/Zv3QhDrqVx2Dt7cCBM3wQA/1477294611/fa77442020a94667c2767228643a645c/helloween-if_i_could_fly.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_1);

            var contentMusic_2 = new MediaContent
            {
                Title = "Future world",
                Description = "helloween-future_world.mp3",
                ContentUrl = "http://tones.mob.org/ringtone/eCue1_rfgV5wKT6OR0khNg/1477295076/38378_wapres_ru/helloween-future_world.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_2);

            var contentMusic_3 = new MediaContent
            {
                Title = "hocus pocus",
                Description = "helloween-hocus_pocus.mp3",
                ContentUrl = "http://tones.mob.org/ringtone/J5mRGlQakIE_SqvLxckD_A/1477295523/22212cc9c43e1694633c7c4eb68ce1d3/helloween-hocus_pocus.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_3);

            // add videos
            var contentVideo_1 = new MediaContent
            {
                Title = "bunny",
                Description = "qpqop sdopdd",
                ContentUrl = "http://video.webmfiles.org/big-buck-bunny_trailer.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_1);

            var contentVideo_2 = new MediaContent
            {
                Title = "happyfit2",
                Description = "cxzcpoiwewne csddqweqw",
                ContentUrl = "http://easyhtml5video.com/images/happyfit2.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_2);

            var contentVideo_3 = new MediaContent
            {
                Title = "techslides",
                Description = "techslides techslides techslides",
                ContentUrl = "http://techslides.com/demos/sample-videos/small.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_3);

            context.SaveChanges();
        }
    }
}
