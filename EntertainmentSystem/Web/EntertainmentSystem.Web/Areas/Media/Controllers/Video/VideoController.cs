namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class VideoController : MediaController
    {
        private readonly IBaseMediaFetcherService videoService;

        public VideoController(IBaseMediaFetcherService videoService)
        {
            this.videoService = videoService;
        }

        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .All()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .AllByTitle(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
        }

        public ActionResult VideoDetails(Guid id)
        {
            return this.View();
        }
    }
}
