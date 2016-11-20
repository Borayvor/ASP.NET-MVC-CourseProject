namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
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
            var result = this.ConditionalActionResult(
                () => this.postService
                .GetAll()
                .To<PostHomeViewModel>(),
                (content) => this.View(content));

            return result;
        }
    }
}
