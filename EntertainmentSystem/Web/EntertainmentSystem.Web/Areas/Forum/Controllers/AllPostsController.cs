namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class AllPostsController : BaseController
    {
        private readonly IForumPostService postService;

        public AllPostsController(IForumPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult Index(
            int page = GlobalConstants.ForumPostsStartPage,
            string search = GlobalConstants.StringEmpty)
        {
            var result = this.ConditionalActionResult(
                () => this.GetPostsPage(page, search),
                (content) => this.View(content));

            return result;
        }

        private PostsPageViewModel GetPostsPage(int page, string search)
        {
            var posts = this.postService.GetAll();

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
                Search = search
            };

            return newViewModel;
        }
    }
}
