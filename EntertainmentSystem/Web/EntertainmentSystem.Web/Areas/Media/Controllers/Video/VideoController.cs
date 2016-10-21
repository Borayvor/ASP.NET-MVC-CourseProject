namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
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

        public ActionResult Index(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return this.ConditionalActionResult(
                () => this.videoService
                .All()
                .To<MediaBaseViewModel>(),
                (videos) => this.View(videos));
            }

            return this.ConditionalActionResult(
                () => this.videoService
                .AllByTitle(search)
                .To<MediaBaseViewModel>(),
                (videos) => this.View("Index", videos));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchVideos(SearchViewModel search)
        {
            return this.RedirectToAction<VideoController>(c => c.Index(search.SearchText));
        }

        public ActionResult VideoDetails(Guid id)
        {
            return this.View();
        }
    }
}
