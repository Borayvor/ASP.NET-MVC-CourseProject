namespace EntertainmentSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminController : BaseController
    {
    }
}
