namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Infrastructure.Filters;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;
    using Web.ViewModels.Search;

    public class VideoController : MediaController
    {
        private readonly IVideoFetcherService videoService;

        public VideoController(IVideoFetcherService videoService)
        {
            this.videoService = videoService;
        }

        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .All()
                .To<MediaBaseViewModel>(),
                (vodeos) => this.View(vodeos));
        }

        public ActionResult VideoDetails(Guid id)
        {
            return this.View();
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchVideos(SearchViewModel search)
        {
            return this.RedirectToAction<VideoController>(c => c.VideosResults(search.SearchText));
        }

        public ActionResult VideosResults(string search)
        {
            return this.ConditionalActionResult(
                () => this.videoService
                .SearchByTitle(search)
                .To<MediaBaseViewModel>(),
                (vodeos) => this.View(vodeos));
        }
    }
}
