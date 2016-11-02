namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
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
            return this.RedirectToActionPermanent(c => c.SearchByTitle(GlobalConstants.StringEmpty));
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
