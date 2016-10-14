namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Fetchers;

    public class VideoController : MediaController
    {
        private readonly IVideoFetcherService videoService;

        public VideoController(IVideoFetcherService videoService)
        {
            this.videoService = videoService;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
