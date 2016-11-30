namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Services.Web;
    using ViewModels;
    using Web.Controllers.Partials;

    public class ForumPostPartialController : BasePartialController
    {
        public ForumPostPartialController(ICacheService cache)
            : base(cache)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPostHomeFromViewModel(
            PostHomeViewModel viewModel,
            string partialViewName,
            int durationInSeconds)
        {
            return this.PartialActionResult(
                viewModel.Id.ToString(),
                () => this.PartialView(partialViewName, viewModel),
                durationInSeconds);
        }
    }
}
