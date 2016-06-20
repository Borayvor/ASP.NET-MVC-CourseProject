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
        private readonly IAdminMediaService<MediaCategory> adminMediaService;

        public AdminMediaCategoryController(IAdminMediaService<MediaCategory> adminMediaService)
        {
            this.adminMediaService = adminMediaService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminMediaCategoryCreateViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Mapper.Map<MediaCategory>(model);

                this.adminMediaService.Create(category);
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, Guid? contentId = null)
        {
            var data = this.adminMediaService.GetAllWithDeleted();

            if (contentId.HasValue)
            {
                data = data.Where(c => c.Id == contentId.Value);
            }

            var result = data
                .To<AdminMediaCategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdminMediaCategoryInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.adminMediaService.GetById(model.Id);

                this.Mapper.Map(model, category);

                this.adminMediaService.Update(category);

                var viewModel = this.Mapper.Map<AdminMediaCategoryViewModel>(category);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AdminMediaCategoryViewModel model)
        {
            if (model != null)
            {
                var currentModel = this.adminMediaService.GetById(model.Id);

                this.adminMediaService.Delete(currentModel);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
