namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
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
        private readonly IMediaAdminService<MediaCategory> adminMediaService;

        public AdminMediaCategoryController(IMediaAdminService<MediaCategory> adminMediaService)
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
                var entity = this.Mapper.Map<MediaCategory>(model);

                this.adminMediaService.Create(entity);
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.adminMediaService
                .GetAllWithDeleted()
                .To<AdminMediaCategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdminMediaCategoryEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.adminMediaService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.adminMediaService.Update(entity);

                var viewModel = this.Mapper.Map<AdminMediaCategoryViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestroyPermanent([DataSourceRequest]DataSourceRequest request, AdminMediaCategoryViewModel model)
        {
            if (model != null)
            {
                var entity = this.adminMediaService.GetById(model.Id);

                this.adminMediaService.DeletePermanent(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
