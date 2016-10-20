namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Fetchers;

    public class PictureController : MediaController
    {
        private readonly IPictureFetcherService pictureService;

        public PictureController(IPictureFetcherService pictureService)
        {
            this.pictureService = pictureService;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
