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
            userManager.PasswordValidator = new MinimumLengthValidator(GlobalConstants.PasswordMinLength);

            var userAdmin = new ApplicationUser
            {
                UserName = AdministratorUserName,
                Email = AdministratorUserName,
                FirstName = AdministratorFirstName,
                LastName = AdministratorLastName,
                AvatarImageUrl = AdministratorImageUrl
            };

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
                AvatarImageUrl = ModeratorImageUrl
            };

            userManager.Create(userModerator, ModeratorPassword);

            // Assign user to moderator role
            userManager.AddToRole(userModerator.Id, GlobalConstants.ModeratorRoleName);

            // Create ordinary user
            var userOrdinary = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "TestUser@TestUser.com",
                FirstName = "FirstName",
                LastName = "LastName",
                AvatarImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/eb/SupermanRoss.png"
            };

            userManager.Create(userOrdinary, "TestUser");

            // End add.
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

        internal static void SeedMediaCollection(EntertainmentSystemDbContext context)
        {
            if (context.MediaCollections.Any())
            {
                return;
            }

            var collection = new MediaCollection
            {
                Name = "Warcraft"
            };

            context.MediaCollections.Add(collection);
            context.SaveChanges();
        }

        internal static void SeedMediaContents(EntertainmentSystemDbContext context)
        {
            const string DefaultCoverImageUrl = "https://dl.dropboxusercontent.com/1/view/jm0poduvuxj8ekh/Apps/EntertainmentSystem/88518440-dd5d-46e3-9f4a-7b2e8c3d8cec.jpg";

            if (context.MediaContents.Any())
            {
                return;
            }

            // add pictures
            var contentPicture_1 = new MediaContent
            {
                Title = "Varian Wrynn",
                Description = "World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/zkg913bztl4zrla/Apps/EntertainmentSystem/91cee43d-0904-4b58-983a-565e09ccd433.jpg",
                ContentType = ContentType.Picture,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCollectionId = context.MediaCollections.FirstOrDefault().Id,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_1);

            var contentPicture_2 = new MediaContent
            {
                Title = "Durotan",
                Description = "Warcraft-Movie-Mobile-Wallpapers-1200x675.jpg",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/i1j0hpk6lpv2mjt/Apps/EntertainmentSystem/bb3f265e-6e89-4d66-9007-b0edeec2796e.jpg",
                ContentType = ContentType.Picture,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCollectionId = context.MediaCollections.FirstOrDefault().Id,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_2);

            var contentPicture_3 = new MediaContent
            {
                Title = "Garona",
                Description = "garona_warcraft_movie-720x1280.jpg",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/b38orxfoi4dj82n/Apps/EntertainmentSystem/b22fc1cc-9b12-4bfe-920b-5594a97b4ab3.jpg",
                ContentType = ContentType.Picture,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCollectionId = context.MediaCollections.FirstOrDefault().Id,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentPicture_3);

            // add music
            var contentMusic_1 = new MediaContent
            {
                Title = "Over The Hills And Far Away",
                Description = "Nightwish - From the Tarja Turunen Era",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/jsgotquu23fqufw/Apps/EntertainmentSystem/84703708-f892-40b5-9472-597b86ab2c12.mp3",
                ContentType = ContentType.Music,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_1);

            var contentMusic_2 = new MediaContent
            {
                Title = "Future World",
                Description = "Helloween - 1987 - Keeper of the Seven Keys pt. 1",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/rcruqp7z3252o7v/Apps/EntertainmentSystem/eea13170-6231-43b5-8f72-6c3a799f1316.mp3",
                ContentType = ContentType.Music,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_2);

            var contentMusic_3 = new MediaContent
            {
                Title = "The Sound of Silence",
                Description = "Disturbed - Immortalized (Deluxe Edition) [2015] Immortalized(Deluxe Edition) 2015",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/3y6eo5y5gjhsqm3/Apps/EntertainmentSystem/b900d55e-c583-45f1-92d0-f7641ef4cee4.mp3",
                ContentType = ContentType.Music,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentMusic_3);

            // add videos
            var contentVideo_1 = new MediaContent
            {
                Title = "Big buck bunny",
                Description = "big-buck-bunny_trailer.webm",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/h1n1noiw8m5b1c6/Apps/EntertainmentSystem/43d770db-e58f-4839-96e4-75e8635f03c2.webm",
                ContentType = ContentType.Video,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_1);

            var contentVideo_2 = new MediaContent
            {
                Title = "Happy feet 2",
                Description = "happyfit2.webm",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/8guai7hzb7bccjh/Apps/EntertainmentSystem/ef1cc222-4328-4710-a580-128019913ed4.webm",
                ContentType = ContentType.Video,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_2);

            var contentVideo_3 = new MediaContent
            {
                Title = "Warcraft",
                Description = "From Legendary Pictures and Universal Pictures comes Warcraft," +
                " an epic adventure of world-colliding conflict based on Blizzard" +
                " Entertainment’s global phenomenon. The peaceful realm of Azeroth stands on" +
                " the brink of war as its civilization faces a fearsome race of invaders: Orc" +
                " warriors fleeing their dying home to colonize another. As a portal opens to" +
                " connect the two worlds, one army faces destruction and the other faces extinction." +
                " From opposing sides, two heroes are set on a collision course that will decide the" +
                " fate of their family, their people and their home. So begins a spectacular saga" +
                " of power and sacrifice in which war has many faces, and everyone fights for something.",
                ContentUrl = "https://dl.dropboxusercontent.com/1/view/tzbpdaf6e35qztt/Apps/EntertainmentSystem/571e0b77-9176-4f71-81fa-9a73063f8ba8.mp4",
                ContentType = ContentType.Video,
                CoverImageUrl = DefaultCoverImageUrl,
                MediaCollectionId = context.MediaCollections.FirstOrDefault().Id,
                MediaCategoryId = context.MediaCategories.FirstOrDefault().Id,
            };

            context.MediaContents.Add(contentVideo_3);

            context.SaveChanges();
        }
    }
}
