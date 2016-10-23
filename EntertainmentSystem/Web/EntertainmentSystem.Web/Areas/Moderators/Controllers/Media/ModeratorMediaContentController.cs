namespace EntertainmentSystem.Web.Areas.Moderators.Controllers.Media
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels.Media;

    public class ModeratorMediaContentController : ModeratorController
    {
        private readonly IMaediaContentService contentService;

        public ModeratorMediaContentController(IMaediaContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.contentService
                .GetAll()
                .To<MediaContentViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MediaContentEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.contentService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.contentService.Update(entity);

                var viewModel = this.Mapper.Map<MediaContentViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, MediaContentViewModel model)
        {
            if (model != null)
            {
                var entity = this.contentService.GetById(model.Id);

                this.contentService.Delete(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
