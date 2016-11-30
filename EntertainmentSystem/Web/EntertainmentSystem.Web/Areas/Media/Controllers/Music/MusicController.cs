namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class MusicController : MediaController
    {
        private readonly IMusicFetcherService musicService;

        public MusicController(IMusicFetcherService musicService)
        {
            this.musicService = musicService;
            this.ViewBag.ControllerName = HtmlConstants.MediaMusicControllerName;
        }

        [HttpGet]
        public ActionResult Index(
            int? page,
            string search = GlobalConstants.StringEmpty,
            string collectionName = GlobalConstants.StringEmpty,
            string categoryName = GlobalConstants.StringEmpty)
        {
            int currentPage = page ?? GlobalConstants.MediaStartPage;

            return this.ConditionalActionResult(
                () => this.GetMediaFilesPage<MediaBaseViewModel>(
                    this.musicService,
                    currentPage,
                    search,
                    collectionName,
                    categoryName),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult MusicDetails(Guid id)
        {
            return this.ConditionalActionResult(
                () => this.Mapper.Map<MediaDetailsViewModel>(this.musicService.GetById(id)),
                (content) => this.View(content));
        }
    }
}
