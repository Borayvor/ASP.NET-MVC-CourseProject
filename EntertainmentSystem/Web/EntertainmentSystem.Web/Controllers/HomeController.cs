namespace EntertainmentSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Partials;
    using Services.Contracts.Media.Fetchers;
    using Services.Web;
    using ViewModels.MediaContent;

    public class HomeController : BasePartialController
    {
        private readonly IMediaContentFetcherService mediaFetcherService;

        public HomeController(IMediaContentFetcherService mediaFetcherService, ICacheService cache)
            : base(cache)
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
        [OutputCache(Duration = 15 * 60)]
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
        [OutputCache(Duration = 15 * 60)]
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
        [OutputCache(Duration = 15 * 60)]
        public ActionResult GetVideos()
        {
            return this.ConditionalActionResult(
               () => this.mediaFetcherService
              .GetLast(ContentType.Video)
              .To<MediaContentHomeViewModel>(),
               (videos) => this.PartialView("_VideosHomePartial", videos));
        }
    }
}
