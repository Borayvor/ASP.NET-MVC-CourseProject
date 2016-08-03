namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System.Web.Mvc;

    public class VideoController : MediaController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
