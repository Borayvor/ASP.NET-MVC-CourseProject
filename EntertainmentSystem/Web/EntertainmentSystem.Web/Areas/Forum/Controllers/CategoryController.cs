namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class CategoryController : BaseController
    {
        private readonly IForumPostService postService;
        private readonly IForumCategoryService categoryService;

        public CategoryController(IForumPostService postService, IForumCategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index(string name)
        {
            var result = this.ConditionalActionResult(
                () => this.postService
                .GetAll()
                .Where(p => p.PostCategory.Name == name)
                .To<PostHomeViewModel>(),
                (content) => this.View(new CategoryPostHomeViewModel
                {
                    CategoryName = name,
                    Posts = content
                }));

            return result;
        }
    }
}
