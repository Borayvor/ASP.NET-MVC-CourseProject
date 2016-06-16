namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Web.Mvc;
    using Controllers;
    using Services.Contracts.Media;

    using Model = Data.Models.Media.MediaCategory;
    using ViewModel = ViewModels.MediaCategoryAdminViewModel;

    public class AdminMediaCategoryController : AdminKendoGridController<Model, ViewModel>
    {
        public AdminMediaCategoryController(IAdminMediaService<Model> administrationMediaService)
            : base(administrationMediaService)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
