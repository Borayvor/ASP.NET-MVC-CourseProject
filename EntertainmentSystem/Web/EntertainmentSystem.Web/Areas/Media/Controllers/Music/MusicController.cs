namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class MusicController : MediaController
    {
        private readonly IBaseMediaFetcherService musicService;

        public MusicController(IBaseMediaFetcherService musicService)
        {
            this.musicService = musicService;
        }

        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.musicService
                .All()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.musicService
                .AllByTitle(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
        }

        public ActionResult MusicDetails(Guid id)
        {
            return this.View();
        }
    }
}
