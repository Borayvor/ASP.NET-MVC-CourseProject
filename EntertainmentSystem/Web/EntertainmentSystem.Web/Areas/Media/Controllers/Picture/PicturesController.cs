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
        public ActionResult Index(
            int? page,
            string search = GlobalConstants.StringEmpty,
            string collectionName = GlobalConstants.StringEmpty,
            string categoryName = GlobalConstants.StringEmpty)
        {
            int currentPage = page ?? GlobalConstants.MediaStartPage;

            return this.ConditionalActionResult(
                () => this.GetMediaFilesPage<MediaBasePictureViewModel>(
                    this.pictureService,
                    currentPage,
                    search,
                    collectionName,
                    categoryName),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.pictureService
                .GetAll(search)
                .To<MediaBasePictureViewModel>(),
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
