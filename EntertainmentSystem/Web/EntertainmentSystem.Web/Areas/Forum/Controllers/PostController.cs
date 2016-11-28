namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common.Constants;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class PostController : BaseController
    {
        private readonly IForumPostService postService;
        private readonly IForumCommentService commentService;
        private readonly IForumCategoryService categoryService;
        private readonly IForumTagService tagService;

        public PostController(
            IForumPostService postService,
            IForumCommentService commentService,
            IForumCategoryService categoryService,
            IForumTagService tagService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult Index(Guid postId, int page = GlobalConstants.ForumStartPage)
        {
            var result = this.ConditionalActionResult(
                () => this.GetPostWithCommentsPage(postId, page),
                (content) => this.View(content));

            return result;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var categories = this.categoryService
                .GetAll()
                .ToList();

            var tags = this.tagService
               .GetAll()
               .Select(x => x.Name)
               .ToArray();

            this.ViewBag.Categories = new SelectList(categories, "Id", "Name");
            this.ViewBag.Tags = tags;

            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel model)
        {

            return this.RedirectToAction<AllPostsController>(c => c.Index(
                GlobalConstants.ForumStartPage,
                GlobalConstants.StringEmpty));
        }

        private PostCommentsPageViewModel GetPostWithCommentsPage(
            Guid postId,
            int page)
        {
            var post = this.Mapper.Map<PostViewModel>(this.postService.GetById(postId));

            int pagesToSkip = (page - 1) * GlobalConstants.ForumCommentsPerPage;

            int totalpages = (int)Math.Ceiling(post.Comments.Count() / (decimal)GlobalConstants.ForumCommentsPerPage);

            // TODO: refactor -> use commentService
            var result = post.Comments
                .OrderByDescending(c => c.CreatedOn)
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ForumCommentsPerPage)
                .ToList();

            post.Comments = result;

            var newViewModel = new PostCommentsPageViewModel
            {
                Post = post,
                CurrentPage = page,
                TotalPages = totalpages
            };

            return newViewModel;
        }
    }
}
