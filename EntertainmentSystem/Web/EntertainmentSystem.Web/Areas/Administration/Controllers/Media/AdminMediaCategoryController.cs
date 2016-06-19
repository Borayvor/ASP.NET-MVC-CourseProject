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

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaCategoryAdminCreateViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Mapper.Map<MediaCategory>(model);

                this.administrationMediaService.Create(category);
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, Guid? contentId = null)
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
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MediaCategoryAdminInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.administrationMediaService.GetById(model.Id);

                this.Mapper.Map(model, category);

                this.administrationMediaService.Update(category);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, MediaCategoryAdminViewModel model)
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
