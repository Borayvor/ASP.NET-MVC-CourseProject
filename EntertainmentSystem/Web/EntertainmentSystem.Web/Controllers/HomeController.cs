namespace EntertainmentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels.Home;
    using ViewModels.MediaContent;

    public class HomeController : BaseController
    {
        private readonly IMediaContentFetcherService contentFetcherService;

        public HomeController(IMediaContentFetcherService contentFetcherService)
        {
            this.contentFetcherService = contentFetcherService;
        }

        public ActionResult Index()
        {
            var pictures = this.contentFetcherService
                .GetLast(ContentType.Picture)
                .To<MediaContentHomeViewModel>()
                .ToList();

            var musics = this.contentFetcherService
                .GetLast(ContentType.Music)
                .To<MediaContentHomeViewModel>()
                .ToList();

            var videos = this.contentFetcherService
                .GetLast(ContentType.Video)
                .To<MediaContentHomeViewModel>()
                .ToList();

            var viewModel = new HomeViewModel
            {
                Pictures = pictures,
                Musics = musics,
                Videos = videos
            };

            return this.View(viewModel);
        }
    }
}
