namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class VideoController : MediaController
    {
        private readonly IVideoFetcherService videoService;

        public VideoController(IVideoFetcherService videoService)
        {
            this.videoService = videoService;
        }

        public ActionResult Index()
        {
            ////var actionResult = this.ConditionalActionResult(
            ////    () => this.videoService
            ////    .GetAll()
            ////    .To<VideoHomeViewModel>(),
            ////    (vodeos) => this.View(vodeos));

            var test = this.videoService
                .GetAll()
                .To<MediaBaseViewModel>()
                .ToList();

            return this.View(test);
        }
    }
}
