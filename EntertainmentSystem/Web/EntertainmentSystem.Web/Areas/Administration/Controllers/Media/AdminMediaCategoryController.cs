namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Controllers;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels;

    public class AdminMediaCategoryController : AdminController
    {
        private readonly IAdminMediaService<MediaCategory> administrationMediaService;

        public AdminMediaCategoryController(IAdminMediaService<MediaCategory> administrationMediaService)
        {
            this.administrationMediaService = administrationMediaService;
        }

        public ActionResult Index(Guid? contentId)
        {
            return this.View(contentId);
        }

        [HttpPost]
        public ActionResult EditingPopupRead([DataSourceRequest] DataSourceRequest request, Guid? contentId = null)
        {
            var data = this.administrationMediaService.GetAllWithDeleted();

            if (contentId.HasValue)
            {
                data = data.Where(c => c.Id == contentId.Value);
            }

            var result = data
                .To<MediaCategoryAdminViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public ActionResult EditingPopupCreate([DataSourceRequest]DataSourceRequest request, MediaCategoryAdminCreateViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Mapper.Map<MediaCategory>(model);

                this.administrationMediaService.Create(category);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult EditingPopupUpdate([DataSourceRequest]DataSourceRequest request, MediaCategoryAdminInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.administrationMediaService.GetById(model.Id);

                this.administrationMediaService.Update(category);
            }
            else if (model != null)
            {
                var category = new MediaCategory
                {
                    Name = model.Name
                };

                this.administrationMediaService.Create(category);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult EditingPopupDestroy([DataSourceRequest]DataSourceRequest request, MediaCategoryAdminViewModel model)
        {
            if (model != null)
            {
                var currentModel = this.administrationMediaService.GetById(model.Id);

                this.administrationMediaService.Delete(currentModel);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
