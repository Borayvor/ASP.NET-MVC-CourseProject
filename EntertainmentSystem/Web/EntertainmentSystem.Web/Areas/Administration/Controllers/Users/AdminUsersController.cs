namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Users
{
    using System.Web.Mvc;

    public class AdminUsersController : AdminController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
