namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Fetchers;

    public class MusicController : MediaController
    {
        private readonly IMusicFetcherService musicService;

        public MusicController(IMusicFetcherService musicService)
        {
            this.musicService = musicService;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
