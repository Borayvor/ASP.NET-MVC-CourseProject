namespace EntertainmentSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class AdminKendoGridController : AdminController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
