namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Fetchers;

    public class PictureController : MediaController
    {
        private readonly IMediaContentFetcherService mediaService;

        public PictureController(IMediaContentFetcherService mediaService)
        {
            this.mediaService = mediaService;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
