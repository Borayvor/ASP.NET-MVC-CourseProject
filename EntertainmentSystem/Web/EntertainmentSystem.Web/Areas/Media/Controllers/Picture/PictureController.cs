namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class PictureController : MediaController
    {
        private readonly IPictureFetcherService pictureService;

        public PictureController(IPictureFetcherService pictureService)
        {
            this.pictureService = pictureService;
        }

        public ActionResult Index()
        {
            var pictures = this.pictureService
                .GetAll()
                .To<MediaBaseViewModel>()
                .ToList();

            return this.View(pictures);
        }
    }
}
