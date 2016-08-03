namespace EntertainmentSystem.Web.Areas.Moderators.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.ModeratorRoleName)]
    public class ModeratorController : BaseController
    {
    }
}
