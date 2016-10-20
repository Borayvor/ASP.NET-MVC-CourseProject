namespace EntertainmentSystem.Web.Areas.Media.Controllers
{
    using System.Web.Mvc;
    using Services.Web;
    using ViewModels;
    using Web.Controllers.Partials;

    [Authorize]
    public class MediaPartialController : BasePartialController
    {
        public MediaPartialController(ICacheService cache)
            : base(cache)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetFromViewModel(
            MediaBaseViewModel viewModel,
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
