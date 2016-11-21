namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Web.Mvc;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class PostController : BaseController
    {
        private readonly IForumPostService postService;

        public PostController(IForumPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult Index(Guid id)
        {
            var result = this.ConditionalActionResult(
                () => this.Mapper.Map<PostViewModel>(this.postService.GetById(id)),
                (content) => this.View(content));

            return result;
        }
    }
}
