﻿namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Contracts.Forum;

    public class PostCategoryController : PostsBaseController
    {
        private readonly IForumCategoryService categoryService;

        public PostCategoryController(IForumPostService postService, IForumCategoryService categoryService)
            : base(postService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index(
            int page = GlobalConstants.ForumStartPage,
            string search = GlobalConstants.StringEmpty,
            string name = GlobalConstants.StringEmpty)
        {
            this.ViewBag.Title = "Category \"" + name + "\"";

            var result = this.ConditionalActionResult(
                () => this.GetPostsPage(
                    this.PostServise.GetAll()
                    .Where(p => p.PostCategory.Name == name),
                    page,
                    search,
                    name),
                (content) => this.View(content));

            return result;
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetCategories()
        {
            var categories = this.categoryService.GetAll().ToList();
            var result = this.Json(categories, JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}
