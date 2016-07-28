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

            // add pictures
            var contentPicture = new MediaContent
            {
                Title = "Test Picture",
                ContentType = ContentType.Picture,
                ContentUrl = "http://i2.wp.com/www.cgmeetup.net/home/wp-content/uploads/2015/11/World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg?resize=960%2C398",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture);

            var contentPicture_1 = new MediaContent
            {
                Title = "pic1",
                Description = "111",
                ContentUrl = "http://i2.wp.com/www.cgmeetup.net/home/wp-content/uploads/2015/11/World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg?resize=960%2C398",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_1);

            var contentPicture_2 = new MediaContent
            {
                Title = "pic2",
                Description = "222",
                ContentUrl = "http://blogs-images.forbes.com/scottmendelson/files/2016/05/Warcraft-Movie-Mobile-Wallpapers-1200x675.jpg",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_2);

            var contentPicture_3 = new MediaContent
            {
                Title = "pic3",
                Description = "333",
                ContentUrl = "http://www.hdwallpapers.in/download/garona_warcraft_movie-720x1280.jpg",
                ContentType = ContentType.Picture,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_3);

            // add music
            var contentMusic = new MediaContent
            {
                Title = "Test Music",
                ContentType = ContentType.Music,
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/4jji3780sr8r1s6/Apps/EntertainmentSystem/9dc6074e-c2e1-4c27-8afa-43d6ecefc2ef",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic);

            var contentMusic_1 = new MediaContent
            {
                Title = "music1",
                Description = "111",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/02-intro.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_1);

            var contentMusic_2 = new MediaContent
            {
                Title = "music2",
                Description = "222",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/17-retrobution.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_2);

            var contentMusic_3 = new MediaContent
            {
                Title = "music3",
                Description = "333",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/22-of-battle-and-ancient-warcraft.mp3",
                ContentType = ContentType.Music,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_3);

            // add videos
            var contentVideo = new MediaContent
            {
                Title = "Test Video",
                ContentType = ContentType.Video,
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/bodhvtk84cgs1js/Apps/EntertainmentSystem/73d967bc-9053-487c-bc3b-2a2ab44b2bab.mp4",
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo);

            var contentVideo_1 = new MediaContent
            {
                Title = "video1",
                Description = "111",
                ContentUrl = "http://video.webmfiles.org/big-buck-bunny_trailer.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_1);

            var contentVideo_2 = new MediaContent
            {
                Title = "video2",
                Description = "222",
                ContentUrl = "http://easyhtml5video.com/images/happyfit2.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_2);

            var contentVideo_3 = new MediaContent
            {
                Title = "video3",
                Description = "333",
                ContentUrl = "http://techslides.com/demos/sample-videos/small.webm",
                ContentType = ContentType.Video,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_3);

            context.SaveChanges();
        }
    }
}
