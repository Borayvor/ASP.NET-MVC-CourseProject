namespace EntertainmentSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels.Media;

    public class HomeController : BaseController
    {
        private readonly IMediaContentFetcherService mediaFetcherService;

        public HomeController(IMediaContentFetcherService mediaFetcherService)
        {
            this.mediaFetcherService = mediaFetcherService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = GlobalConstants.MediaHomeCacheDuration)]
        public ActionResult GetMusic()
        {
            return this.ConditionalActionResult(
                () => this.mediaFetcherService
               .GetLast(ContentType.Music)
               .To<MediaContentHomeViewModel>(),
                (music) => this.PartialView("_MusicHomePartial", music));
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = GlobalConstants.MediaHomeCacheDuration)]
        public ActionResult GetPictures()
        {
            return this.ConditionalActionResult(
               () => this.mediaFetcherService
              .GetLast(ContentType.Picture)
              .To<MediaContentHomeViewModel>(),
               (pictures) => this.PartialView("_PicturesHomePartial", pictures));
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = GlobalConstants.MediaHomeCacheDuration)]
        public ActionResult GetVideos()
        {
            return this.ConditionalActionResult(
               () => this.mediaFetcherService
              .GetLast(ContentType.Video)
              .To<MediaContentHomeViewModel>(),
               (videos) => this.PartialView("_VideosHomePartial", videos));
        }

        [HttpGet]
        public ActionResult Error()
        {
            return this.View();
        }
    }
}
