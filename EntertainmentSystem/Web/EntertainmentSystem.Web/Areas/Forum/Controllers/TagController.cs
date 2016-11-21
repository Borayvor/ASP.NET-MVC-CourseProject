namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class TagController : BaseController
    {
        private readonly IForumPostService postService;
        private readonly IForumTagService tagService;

        public TagController(IForumPostService postService, IForumTagService tagService)
        {
            this.postService = postService;
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult Index(string name)
        {
            var result = this.ConditionalActionResult(
                () => this.postService
                .GetAll()
                .Where(p => p.Tags.Where(x => x.Name == name).Any())
                .To<PostHomeViewModel>(),
                (content) => this.View(new TagPostsHomeViewModel
                {
                    TagName = name,
                    Posts = content
                }));

            return result;
        }
    }
}
