namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Web.Mvc;
    using Web.Controllers;

    public class AdminMediaCategoryController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
