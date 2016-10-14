namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class MusicController : MediaController
    {
        private readonly IMusicFetcherService musicService;

        public MusicController(IMusicFetcherService musicService)
        {
            this.musicService = musicService;
        }

        public ActionResult Index()
        {
            var musics = this.musicService
                .GetAll()
                .To<MediaBaseViewModel>()
                .ToList();

            return this.View(musics);
        }
    }
}
