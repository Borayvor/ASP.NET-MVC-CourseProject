namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Linq;
    using Common.Constants;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public abstract class PostsBaseController : BaseController
    {
        private const string PageTitleName = "Forum";

        private readonly IForumPostService postService;

        public PostsBaseController(IForumPostService postService)
        {
            this.postService = postService;
            this.ViewBag.Title = PageTitleName;
        }

        protected IForumPostService PostServise
        {
            get { return this.postService; }
        }

        protected PostsPageViewModel GetPostsPage(
            IQueryable<Post> posts,
            int page = GlobalConstants.ForumStartPage,
            string search = GlobalConstants.StringEmpty,
            string name = GlobalConstants.StringEmpty)
        {
            int totalpages = 0;
            int pagesToSkip = (page - 1) * GlobalConstants.ForumPostsPerPage;

            if (!string.IsNullOrWhiteSpace(search))
            {
                posts = posts.Where(x => x.Title.ToLower().Contains(search.ToLower()));
            }

            totalpages = (int)Math.Ceiling(posts.Count() / (decimal)GlobalConstants.ForumPostsPerPage);

            var result = posts
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ForumPostsPerPage)
                .To<PostHomeViewModel>()
                .ToList();

            var newViewModel = new PostsPageViewModel
            {
                Posts = result,
                CurrentPage = page,
                TotalPages = totalpages,
                Search = search,
                Option = name
            };

            return newViewModel;
        }
    }
}
