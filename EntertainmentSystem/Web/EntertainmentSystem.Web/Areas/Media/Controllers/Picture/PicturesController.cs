namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class PicturesController : MediaController
    {
        private readonly IPictureFetcherService pictureService;

        public PicturesController(IPictureFetcherService pictureService)
        {
            this.pictureService = pictureService;
            this.ViewBag.ControllerName = HtmlConstants.MediaPicturesControllerName;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.pictureService
                .All()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.pictureService
                .All(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
        }

        [HttpGet]
        public ActionResult PictureDetails(Guid id)
        {
            return this.ConditionalActionResult(
                () => this.Mapper.Map<MediaDetailsViewModel>(this.pictureService.GetById(id)),
                (content) => this.View(content));
        }
    }
}
