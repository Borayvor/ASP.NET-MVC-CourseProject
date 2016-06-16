namespace EntertainmentSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Common.Models;
    using ViewModels;

    public abstract class AdminKendoGridController<TDbModel, TViewModel> : AdminController
        where TDbModel : IAuditInfo, IDeletableEntity
        where TViewModel : AdminViewModel
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
