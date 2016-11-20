namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
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
        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.musicService
                .GetAll()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.musicService
                .GetAll(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
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
