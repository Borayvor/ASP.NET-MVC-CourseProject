namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Contracts.Forum;

    public class AllPostsController : PostsBaseController
    {
        public AllPostsController(IForumPostService postService)
            : base(postService)
        {
        }

        [HttpGet]
        public ActionResult Index(
            int page = GlobalConstants.ForumStartPage,
            string search = GlobalConstants.StringEmpty)
        {
            var name = string.Empty;

            var result = this.ConditionalActionResult(
                () => this.GetPostsPage(
                    this.PostServise.GetAll(),
                    page,
                    search,
                    name),
                (content) => this.View(content));

            return result;
        }
    }
}
