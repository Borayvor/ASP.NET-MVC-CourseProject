namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Web.Controllers;

    public class CommentController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }
    }
}
