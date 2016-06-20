namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels;

    public class AdminMediaContentController : AdminController
    {
        private readonly IAdminMediaService<MediaContent> adminMediaService;

        public AdminMediaContentController(IAdminMediaService<MediaContent> adminMediaService)
        {
            this.adminMediaService = adminMediaService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.adminMediaService
                .GetAllWithDeleted()
                .To<AdminMediaContentViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdminMediaContentEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.adminMediaService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.adminMediaService.Update(entity);

                var viewModel = this.Mapper.Map<AdminMediaContentViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AdminMediaContentViewModel model)
        {
            if (model != null)
            {
                var entity = this.adminMediaService.GetById(model.Id);

                this.adminMediaService.Delete(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
