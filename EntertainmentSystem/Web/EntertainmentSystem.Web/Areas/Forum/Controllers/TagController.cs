namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Contracts.Forum;

    public class TagController : PostsBaseController
    {
        private readonly IForumTagService tagService;

        public TagController(IForumPostService postService, IForumTagService tagService)
            : base(postService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult Index(
            int page = GlobalConstants.ForumStartPage,
            string search = GlobalConstants.StringEmpty,
            string name = GlobalConstants.StringEmpty)
        {
            this.ViewBag.Title = "Tag \"" + name + "\"";

            var result = this.ConditionalActionResult(
                () => this.GetPostsPage(
                    this.PostServise.GetAll()
                    .Where(p => p.Tags.Where(x => x.Name == name).Any()),
                page,
                search,
                name),
                (content) => this.View(content));

            return result;
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetTags()
        {
            var tags = this.tagService.GetAll().ToList();
            var result = this.Json(tags, JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}
