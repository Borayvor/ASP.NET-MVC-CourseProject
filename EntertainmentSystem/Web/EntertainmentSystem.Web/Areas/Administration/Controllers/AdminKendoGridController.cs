namespace EntertainmentSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels;

    public abstract class AdminKendoGridController<TDbModel, TViewModel> : AdminController
        where TDbModel : IAuditInfo, IDeletableEntity
        where TViewModel : AdminViewModel
    {
        private readonly IAdminMediaService<TDbModel> administrationMediaService;

        public AdminKendoGridController(IAdminMediaService<TDbModel> administrationMediaService)
        {
            this.administrationMediaService = administrationMediaService;
        }

        [HttpPost]
        public virtual ActionResult Read([DataSourceRequest]DataSourceRequest request, Guid? id = null)
        {
            var data = this.administrationMediaService
                .GetAllWithDeleted()
                .AsQueryable()
                .To<TViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }
    }
}
