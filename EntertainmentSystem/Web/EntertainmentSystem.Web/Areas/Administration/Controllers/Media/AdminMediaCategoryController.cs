namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Controllers;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;

    using Model = Data.Models.Media.MediaCategory;
    using ViewModel = ViewModels.MediaCategoryAdminViewModel;

    public class AdminMediaCategoryController : AdminKendoGridController<Model, ViewModel>
    {
        public AdminMediaCategoryController(IAdminMediaService<Model> administrationMediaService)
            : base(administrationMediaService)
        {
        }

        public ActionResult Index(Guid? contentId)
        {
            return this.View(contentId);
        }

        [HttpPost]
        public override ActionResult Read(DataSourceRequest request, Guid? contentId = null)
        {
            var data = this.AdministrationMediaService.GetAllWithDeleted().AsQueryable();

            if (contentId.HasValue)
            {
                data = data.Where(c => c.Id == contentId.Value);
            }

            return this.Json(data.To<ViewModel>().ToDataSourceResult(request));
        }
    }
}
