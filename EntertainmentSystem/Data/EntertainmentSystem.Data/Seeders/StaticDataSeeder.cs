namespace EntertainmentSystem.Data.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EntertainmentSystem.Common.Constants;
    using EntertainmentSystem.Common.Generators;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Forum;
    using Models.Media;

    internal static class StaticDataSeeder
    {
        private const string AdministratorUserName = "Admin";
        private const string ModeratorUserName = "Moderator";
        private const string UserOrdinaryUserName = "TestUser";
        private const int VotePointsInit = 0;

        private static List<Post> postList;
        private static Guid theTestPostId;

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

            // admin
            const string AdministratorEmail = "admin@admin.com";
            const string AdministratorFirstName = "Admincho";
            const string AdministratorLastName = "Adminov";
            const string AdministratorPassword = "admin";
            const string AdministratorImageUrl = "http://vignette4.wikia.nocookie.net/marveldatabase/images/4/41/Boreas_0001.jpg/revision/latest?cb=20110201173602";

            // moderator
            const string ModeratorEmail = "moderator@moderator.com";
            const string ModeratorFirstName = "Gosho";
            const string ModeratorLastName = "Peshev";
            const string ModeratorPassword = "moderator";
            const string ModeratorImageUrl = "http://batman-news.com/wp-content/uploads/2014/01/logo-snb.png";

            // user
            const string UserOrdinaryEmail = "testuser@TestUser.com";
            const string UserOrdinaryFirstName = "FirstName";
            const string UserOrdinaryLastName = "LastName";
            const string UserOrdinaryPassword = "testuser";
            const string UserOrdinaryImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/eb/SupermanRoss.png";

            // Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new MinimumLengthValidator(GlobalConstants.PasswordMinLength);

            var userAdmin = new ApplicationUser
            {
                Email = AdministratorEmail,
                UserName = AdministratorUserName,
                FirstName = AdministratorFirstName,
                LastName = AdministratorLastName,
                AvatarImageUrl = AdministratorImageUrl,
                VotePoints = VotePointsInit
            };

            userManager.Create(userAdmin, AdministratorPassword);

            // Assign user to admin role
            userManager.AddToRole(userAdmin.Id, GlobalConstants.AdministratorRoleName);

            // Create moderator user
            var userModerator = new ApplicationUser
            {
                Email = ModeratorEmail,
                UserName = ModeratorUserName,
                FirstName = ModeratorFirstName,
                LastName = ModeratorLastName,
                AvatarImageUrl = ModeratorImageUrl,
                VotePoints = VotePointsInit
            };

            userManager.Create(userModerator, ModeratorPassword);

            // Assign user to moderator role
            userManager.AddToRole(userModerator.Id, GlobalConstants.ModeratorRoleName);

            // Create ordinary user
            var userOrdinary = new ApplicationUser
            {
                Email = UserOrdinaryEmail,
                UserName = UserOrdinaryUserName,
                FirstName = UserOrdinaryFirstName,
                LastName = UserOrdinaryLastName,
                AvatarImageUrl = UserOrdinaryImageUrl,
                VotePoints = VotePointsInit
            };

            userManager.Create(userOrdinary, UserOrdinaryPassword);

            // End add.
            context.SaveChanges();
        }

        internal static void SeedPostCategories(EntertainmentSystemDbContext context)
        {
            if (context.ForumCategories.Any())
            {
                return;
            }

            var category = new PostCategory
            {
                Name = "Unknown"
            };

            context.ForumCategories.Add(category);
            context.SaveChanges();
        }

        internal static void SeedPosts(EntertainmentSystemDbContext context)
        {
            if (context.ForumPosts.Any())
            {
                return;
            }

            Post post;

            for (int i = 0; i < 10; i++)
            {
                post = new Post
                {
                    Title = "Test Post " + i,
                    Content = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                    AuthorId = context.Users.FirstOrDefault(a => a.UserName == ModeratorUserName).Id,
                    PostCategoryId = context.ForumCategories.FirstOrDefault().Id,
                };

                context.ForumPosts.Add(post);
            }

            context.SaveChanges();

            post = new Post
            {
                Title = "The Test Post",
                Content = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                AuthorId = context.Users.FirstOrDefault(a => a.UserName == ModeratorUserName).Id,
                PostCategoryId = context.ForumCategories.FirstOrDefault().Id,
            };

            theTestPostId = post.Id;

            context.ForumPosts.Add(post);
            context.SaveChanges();

            postList = context.ForumPosts.OrderByDescending(x => x.CreatedOn).ToList();
        }

        internal static void SeedTags(EntertainmentSystemDbContext context)
        {
            if (context.ForumTags.Any())
            {
                return;
            }

            Tag tag;

            for (int i = 0; i < 7; i++)
            {
                tag = new Tag
                {
                    Name = "Test Tag " + i,
                    Posts = new List<Post> { postList[RandomGenerator.RandomNumber(0, postList.Count - 1)] }
                };

                context.ForumTags.Add(tag);
            }

            context.SaveChanges();

            tag = new Tag
            {
                Name = "The Test Tag",
                Posts = context.ForumPosts.ToList()
            };

            context.ForumTags.Add(tag);

            context.SaveChanges();
        }

        internal static void SeedPostComments(EntertainmentSystemDbContext context)
        {
            if (context.ForumComments.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var postComment = new Comment
                {
                    Content = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                    AuthorId = context.Users.FirstOrDefault(a => a.UserName == UserOrdinaryUserName).Id,
                    PostId = theTestPostId
                };

                context.ForumComments.Add(postComment);
            }

            context.SaveChanges();
        }

        internal static void SeedPostVotes(EntertainmentSystemDbContext context)
        {
            if (context.ForumVotes.Any())
            {
                return;
            }

            // post votes
            var user = context.Users.FirstOrDefault(a => a.UserName == UserOrdinaryUserName);

            var vote = new Vote
            {
                AuthorId = user.Id,
                PostId = theTestPostId,
                Value = (VoteType)RandomGenerator.RandomNumber(-1, 1)
            };

            context.ForumVotes.Add(vote);
            user.VotePoints += (int)vote.Value;

            // comment votes
            var commentIds = context.ForumComments.Select(x => x.Id).ToList();
            user = context.Users.FirstOrDefault(a => a.UserName == ModeratorUserName);

            for (int i = 0; i < 30; i++)
            {
                var commentId = commentIds[RandomGenerator.RandomNumber(0, commentIds.Count - 1)];

                vote = new Vote
                {
                    AuthorId = user.Id,
                    CommentId = context.ForumComments.FirstOrDefault(c => c.Id == commentId).Id,
                    Value = (VoteType)RandomGenerator.RandomNumber(-1, 1)
                };

                context.ForumVotes.Add(vote);
                user.VotePoints += (int)vote.Value;
            }

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
