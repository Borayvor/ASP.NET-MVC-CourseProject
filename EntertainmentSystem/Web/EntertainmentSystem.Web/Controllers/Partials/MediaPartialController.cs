namespace EntertainmentSystem.Web.Controllers.Partials
{
    using System.Web.Mvc;
    using Services.Web;
    using ViewModels.MediaContent;

    public class MediaPartialController : BasePartialController
    {
        public MediaPartialController(ICacheService cache)
            : base(cache)
        {
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetFromViewModel(
            MediaContentHomeViewModel viewModel,
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
