namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;

    public class PostController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
