namespace EntertainmentSystem.Web.Areas.Media.Controllers.Music
{
    using System.Web.Mvc;

    public class MusicController : MediaController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
