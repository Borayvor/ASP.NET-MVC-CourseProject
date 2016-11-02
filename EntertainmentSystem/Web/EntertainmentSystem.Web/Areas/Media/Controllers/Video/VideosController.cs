namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class VideosController : MediaController
    {
        private readonly IVideoFetcherService videoService;

        public VideosController(IVideoFetcherService videoService)
        {
            this.videoService = videoService;
            this.ViewBag.ControllerName = HtmlConstants.MediaVideosControllerName;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .All()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .All(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
        }

        [HttpGet]
        public ActionResult VideoDetails(Guid id)
        {
            return this.ConditionalActionResult(
                () => this.Mapper.Map<MediaDetailsViewModel>(this.videoService.GetById(id)),
                (content) => this.View(content));
        }
    }
}
