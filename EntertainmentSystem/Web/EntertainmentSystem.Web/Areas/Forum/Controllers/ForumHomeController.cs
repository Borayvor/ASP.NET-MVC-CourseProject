namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class ForumHomeController : BaseController
    {
        private readonly IForumPostService postService;

        public ForumHomeController(IForumPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var posts = this.postService
                .GetAll()
                .To<PostHomeViewModel>()
                .ToList();

            return this.View(posts);
        }
    }
}
