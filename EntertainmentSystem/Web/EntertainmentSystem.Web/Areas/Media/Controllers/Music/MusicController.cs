namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
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
            return this.RedirectToActionPermanent(c => c.SearchByTitle(GlobalConstants.StringEmpty));
        }

        [HttpGet]
        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.musicService
                .All(search)
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
